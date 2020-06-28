using System;

using UIKit;

namespace Mailbox.iOS
{
    public partial class ViewController : UIViewController
    {
        int count = 1;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        UITableView tableView;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            tableView = new UITableView(this.View.Frame);
            this.View.Add(tableView);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}
