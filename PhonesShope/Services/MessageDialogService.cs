using PhonesShope.Pages.OtherPages;

namespace PhonesShope.Services
{
    public class MessageDialogService
    {
        public MessageDialog? messageDialog;
        public bool ShowBusyButton { get; set; }
        public bool ShowSaveButton { get; set; } = true;
        public Action? Action { get; set; }

        public async void SetMessageDialog(bool success)
        {
            await messageDialog!.ShowMessage();

            // Check the success flag and update the buttons accordingly
            ShowBusyButton = false;
            ShowSaveButton = !success;

            Action!.Invoke();
        }
    }
}
