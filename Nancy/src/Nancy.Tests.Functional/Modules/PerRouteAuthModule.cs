﻿namespace Nancy.Tests.Functional.Modules
{
    using Nancy.Security;

    public class PerRouteAuthModule : NancyModule
    {
        public PerRouteAuthModule()
        {
            Get["/nonsecured"] = _ => 200;

            Get["/secured"] = _ =>
            {
                this.RequiresAuthentication();

                return 200;
            };

            Get["/requiresclaims"] = _ =>
            {
                this.RequiresClaims(c => c.Type == "test", c => c.Type == "test2");

                return 200;
            };

            Get["/requiresanyclaims"] = _ =>
            {
                this.RequiresAnyClaim(c => c.Type == "test", c => c.Type == "test2");

                return 200;
            };
        }
    }
}