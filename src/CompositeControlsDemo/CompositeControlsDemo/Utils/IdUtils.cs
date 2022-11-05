using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Binding.Properties;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Compilation.ControlTree;
using DotVVM.Framework.Compilation;
using DotVVM.Framework.Utils;
using System.Linq.Expressions;
using DotVVM.Framework.Controls;

namespace CompositeControlsDemo.Utils;

public class IdUtils
{

    public static ValueOrBinding<string> GetTabIndexIdFragment(BindingCompilationService bindingService, DataContextStack dataContext)
    {
        var indexBinding = bindingService.Cache.CreateCachedBinding(
            "_index", new object[] { dataContext },
            () => new ValueBindingExpression<string>(bindingService, new object?[]
                {
                    dataContext,
                    new ParsedExpressionBindingProperty(
                        ExpressionUtils.Replace(
                            (int id) => "_tab" + id,
                            Expression.Parameter(typeof(int), "_index")
                                .AddParameterAnnotation(new BindingParameterAnnotation(dataContext, new CurrentCollectionIndexExtensionParameter()))
                            )
                    )
                }));
        return new ValueOrBinding<string>(indexBinding);
    }

    public static ValueOrBinding<string> ConcatStringBindings(BindingCompilationService bindingService, ValueOrBinding<string> a, ValueOrBinding<string> b)
    {
        if (!a.HasBinding && !b.HasBinding)
        {
            return new ValueOrBinding<string>(a.ValueOrDefault + b.ValueOrDefault);
        }
        else if (a.HasBinding && !b.HasBinding)
        {
            return a.Select(x => x + b.ValueOrDefault);
        }
        else if (!a.HasBinding && b.HasBinding)
        {
            return b.Select(x => a.ValueOrDefault + x);
        }
        else
        {
            var aBinding = a.BindingOrDefault!;
            var bBinding = b.BindingOrDefault!;
            if (!Equals(aBinding.DataContext, bBinding.DataContext))
            {
                throw new DotvvmCompilationException("Cannot concat bindings with different DataContextStacks!");
            }

            var aExpression = (LambdaExpression)aBinding.GetProperty<ParsedExpressionBindingProperty>().Expression;
            var bExpression = (LambdaExpression)bBinding.GetProperty<ParsedExpressionBindingProperty>().Expression;

            var bExpressionWithAParameter = ExpressionUtils.Replace(bExpression, aExpression.Parameters[0]);
            var newExpressionBody = ExpressionUtils.Replace((string aValue, string bValue) => aValue + bValue, aExpression.Body, bExpressionWithAParameter);

            var newBinding = new ValueBindingExpression(bindingService, new object[]
            {
                    aBinding.DataContext,
                    new ParsedExpressionBindingProperty(Expression.Lambda(newExpressionBody, aExpression.Parameters[0]))
            });
            return new ValueOrBinding<string>(newBinding);
        }
    }

    public static ValueOrBinding<T> TransferToChildContext<T>(BindingCompilationService bindingService, ValueOrBinding<T> valueOrBinding, DataContextStack newDataContextStack)
    {
        if (valueOrBinding.BindingOrDefault is { } binding)
        {
            var expression = (LambdaExpression)binding.GetProperty<ParsedExpressionBindingProperty>().Expression;
            var visitor = new TransferToChildContextExpressionVisitor(expression.Parameters[0]);
            var childExpression = visitor.Visit(expression);

            var newBinding = new ValueBindingExpression(bindingService, new object[]
                {
                        newDataContextStack,
                        new ParsedExpressionBindingProperty(childExpression)
                });
            return new ValueOrBinding<T>(newBinding);
        }
        else
        {
            return valueOrBinding;
        }
    }

    class TransferToChildContextExpressionVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression dataContextHierarchyParameter;

        public TransferToChildContextExpressionVisitor(ParameterExpression dataContextHierarchyParameter)
        {
            this.dataContextHierarchyParameter = dataContextHierarchyParameter;
        }

        protected override Expression VisitIndex(IndexExpression node)
        {
            if (node.Object == dataContextHierarchyParameter)
            {
                // accessing element on the data context hierarchy
                return Expression.ArrayIndex(
                    node.Object,
                    Expression.Add(
                        node.Arguments[0],
                        Expression.Constant(1)
                    )
                );
            }
            return base.VisitIndex(node);
        }
    }

}