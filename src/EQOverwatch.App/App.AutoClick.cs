using EQOverwatch.App.ViewModels;

namespace EQOverwatch.App;

// The CH auto-press presses real keys in the app (EQ Overwatch Advanced); tests supply a fake.
public partial class CompanionApp
{
    partial void OnEditionViewModelCreated(MainViewModel viewModel) => viewModel.SetClickSender(new EQOverwatch.App.Interop.Win32InputClicker());
}
