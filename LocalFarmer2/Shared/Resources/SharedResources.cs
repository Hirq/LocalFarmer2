using Microsoft.Extensions.Localization;

namespace LocalFarmer2.Shared.Resources
{
    public class SharedResources
    {
        private readonly IStringLocalizer<SharedResources> _localizer;

        public SharedResources(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
        }

        public string this[string key] => _localizer[key];
    }
}
