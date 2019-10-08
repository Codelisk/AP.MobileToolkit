﻿using Prism.Logging;
using Prism.Navigation;
using Prism.Services;

namespace ToolkitDemo.ViewModels
{
    public class RadioButtonPageViewModel : PageViewModelBase
    {
        public RadioButtonPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, ILogger logger)
            : base(navigationService, pageDialogService, logger)
        {
            PageName = GetType().Name.Replace("ViewModel", string.Empty);
        }
    }
}
