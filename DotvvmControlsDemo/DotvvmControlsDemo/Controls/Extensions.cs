using System;
using System.Linq.Expressions;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Properties;
using DotVVM.Framework.Utils;

namespace DotvvmControlsDemo.Controls
{
    public static class Extensions
    {

        public static ValueOrBinding<TResult> Derive<T, TResult>(this ValueOrBinding<T> binding, Expression<Func<T, TResult>> method)
        {
            return binding.Process(
                v => method.Compile()(v),
                b => new ValueOrBinding<TResult>(
                        b.DeriveBinding(
                            new ParsedExpressionBindingProperty(
                                ExpressionUtils.Replace(
                                    method,
                                    b.GetProperty<ParsedExpressionBindingProperty>().Expression)))
                        )
            );
        }

        public static ValueOrBinding<TResult> Derive<T, TResult, T1>(this ValueOrBinding<T> binding, Expression<Func<T, T1, TResult>> method, T1 arg1)
        {
            return binding.Process(
                v => method.Compile()(v, arg1),
                b => new ValueOrBinding<TResult>(
                        b.DeriveBinding(
                            new ParsedExpressionBindingProperty(
                                ExpressionUtils.Replace(
                                    method,
                                    b.GetProperty<ParsedExpressionBindingProperty>().Expression,
                                    Expression.Constant(arg1))))
                        )
            );
        }

        public static ValueOrBinding<TResult> Derive<T, TResult, T1, T2>(this ValueOrBinding<T> binding, Expression<Func<T, T1, T2, TResult>> method, T1 arg1, T2 arg2)
        {
            return binding.Process(
                v => method.Compile()(v, arg1, arg2),
                b => new ValueOrBinding<TResult>(
                        b.DeriveBinding(
                            new ParsedExpressionBindingProperty(
                                ExpressionUtils.Replace(
                                    method,
                                    b.GetProperty<ParsedExpressionBindingProperty>().Expression,
                                    Expression.Constant(arg1),
                                    Expression.Constant(arg2))))
                        )
            );
        }

        public static ValueOrBinding<TResult> Derive<T, TResult, T1, T2, T3>(this ValueOrBinding<T> binding, Expression<Func<T, T1, T2, T3, TResult>> method, T1 arg1, T2 arg2, T3 arg3)
        {
            return binding.Process(
                v => method.Compile()(v, arg1, arg2, arg3),
                b => new ValueOrBinding<TResult>(
                        b.DeriveBinding(
                            new ParsedExpressionBindingProperty(
                                ExpressionUtils.Replace(
                                    method,
                                    b.GetProperty<ParsedExpressionBindingProperty>().Expression,
                                    Expression.Constant(arg1),
                                    Expression.Constant(arg2),
                                    Expression.Constant(arg3))))
                        )
            );
        }

        public static ValueOrBinding<TResult> Derive<T, TResult, T1, T2, T3, T4>(this ValueOrBinding<T> binding, Expression<Func<T, T1, T2, T3, T4, TResult>> method, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return binding.Process(
                v => method.Compile()(v, arg1, arg2, arg3, arg4),
                b => new ValueOrBinding<TResult>(
                        b.DeriveBinding(
                            new ParsedExpressionBindingProperty(
                                ExpressionUtils.Replace(
                                    method,
                                    b.GetProperty<ParsedExpressionBindingProperty>().Expression,
                                    Expression.Constant(arg1),
                                    Expression.Constant(arg2),
                                    Expression.Constant(arg3),
                                    Expression.Constant(arg4))))
                        )
            );
        }

    }
}
