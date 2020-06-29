using Foundation;
using System;
using UIKit;

namespace Mailbox.iOS
{
    public partial class MailsTableViewController : UITableViewController
    {
        public MailsTableViewController (IntPtr handle) : base (handle)
        {
        }

        EmailServer emailserver = new EmailServer();
        const string CellId = "EmailCell";

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellId);
            if (cell == null )
            {
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellId);
                cell.TextLabel.TextColor = UIColor.Blue;
                cell.DetailTextLabel.TextColor = UIColor.LightGray;
                cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

            }
            else if (cell.ImageView.Image != null)
            {
                cell.ImageView.Image.Dispose();
            }

            var item = emailserver.Email[indexPath.Row];
            cell.TextLabel.Font = UIFont.FromName("Helvetica Light", 14);
            cell.DetailTextLabel.Font = UIFont.FromName("Helvetica Light", 12);
            

            cell.TextLabel.Text = item.Subject;
            cell.DetailTextLabel.Text = item.Body;
            cell.ImageView.Image = item.GetImage();
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return emailserver.Email.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {

            var storyboard = UIStoryboard.FromName("Main", null);
            var detailViewController =
                 (DetailsViewController)storyboard.InstantiateViewController(
                    "DetailsViewController");


            var emailItem = emailserver.Email[indexPath.Row];
            detailViewController.Item = emailItem;

            PresentViewController(detailViewController, true, null);
        }
    }
}