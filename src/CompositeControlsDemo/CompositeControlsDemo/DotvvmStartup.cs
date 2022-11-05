using CompositeControlsDemo.Controls.Forms;
using CompositeControlsDemo.Controls.Menus;
using CompositeControlsDemo.Controls.Panels;
using CompositeControlsDemo.Controls.PhoneNumbers;
using CompositeControlsDemo.Controls.TabControls;
using CompositeControlsDemo.Controls.Thumbnails.List;
using CompositeControlsDemo.Controls.Thumbnails.Placeholder;
using CompositeControlsDemo.Presenter;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Framework.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace CompositeControlsDemo
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {

            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("Default", "", "Views/Default.dothtml");
            config.RouteTable.Add("Menus", "Menus/{PageIndex?}", "Views/Menus.dothtml");
            config.RouteTable.AutoDiscoverRoutes(new DefaultRouteStrategy(config));    

            config.RouteTable.Add("Identicon", "identicon/{size}", _ => new IdenticonPresenter());
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
            // register code-only controls and markup controls
            config.Markup.AddCodeControls("cc", typeof(PhoneNumber1));
            
            config.Markup.AddCodeControls("cc", typeof(StringField));

            config.Markup.AddCodeControls("cc", typeof(ThumbnailListComposite));
            
            config.Markup.AddMarkupControl("cc", "ThumbnailPlaceholder", "Controls/Thumbnails/Placeholder/ThumbnailPlaceholder.dotcontrol");
            config.Markup.AddCodeControls("cc", typeof(ThumbnailPlaceholderComposite));

            config.Markup.AddCodeControls("cc", typeof(Panel));

            config.Markup.AddCodeControls("cc", typeof(Menu));

            config.Markup.AddCodeControls("cc", typeof(TabControl));
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            // register custom resources and adjust paths to the built-in resources
            config.Resources.RegisterStylesheetFile("bootstrap-css", "wwwroot/bootstrap/css/bootstrap.min.css");
            config.Resources.RegisterScriptFile("bootstrap", "wwwroot/bootstrap/js/bootstrap.bundle.min.js", dependencies: new[] { "bootstrap-css" });
            config.Resources.RegisterStylesheetFile("phoneNumber", "wwwroot/phoneNumber.css");
        }

        public void ConfigureServices(IDotvvmServiceCollection options)
        {
            options.AddDefaultTempStorages("temp");
            options.AddHotReload();
		}
    }
}
