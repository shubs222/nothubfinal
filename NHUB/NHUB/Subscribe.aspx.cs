using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Repository;
using System.Data;
using Microsoft.AspNet.Identity;

namespace NHUB
{
    public partial class Subscribe : System.Web.UI.Page
    {
        AddNotificationRepository addNotificationRepository = new AddNotificationRepository();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int qstring = Convert.ToInt32(Request.QueryString["Id"]);
            DataTable tb = addNotificationRepository.GetEventData(0).Tables[0];
            DataRow dr = tb.Select("Id = " + qstring)[0];

            EventName.Text = dr[1].ToString();
            ConfCheck.Enabled = false;
            MandCheck.Enabled = false;
            if (dr[4].ToString()=="True")
            {
                ConfCheck.Enabled = true;
                ConfCheck.Checked = true;
            }
            if (dr[3].ToString() == "True")
            {
                MandCheck.Enabled = true;
                MandCheck.Checked = true;
            }

            DataTable tb1 = addNotificationRepository.EventChannelGetData(qstring).Tables[0];
            if (!IsPostBack)
            {
                IntranetCheck.Enabled = false;
                SmsCheckBox.Enabled = false;
                UnabotCheckBox.Enabled = false;
                EmailCheckbox.Enabled = false;

                for (int count = 0; count < tb1.Rows.Count; count++)
                {
                    //    if(tb1.Rows[count])
                    if (Convert.ToInt32(tb1.Rows[count][0]) == 1)
                    {
                        IntranetCheck.Enabled = true;
                        IntranetCheck.Checked = true;
                    }
                    if (Convert.ToInt32(tb1.Rows[count][0]) == 2)
                    {
                        EmailCheckbox.Enabled = true;
                        EmailCheckbox.Checked = true;
                    }
                    if (Convert.ToInt32(tb1.Rows[count][0]) == 3)
                    {
                        UnabotCheckBox.Enabled = true;
                        UnabotCheckBox.Checked = true;
                    }
                    if (Convert.ToInt32(tb1.Rows[count][0]) == 4)
                    {
                        SmsCheckBox.Enabled = true;
                        SmsCheckBox.Checked = true;
                    }

                }
            }
            
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            int qstring = Convert.ToInt32(Request.QueryString["Id"]);
            EventSubsribeNotification eventSubsribeNotification = new EventSubsribeNotification();
            int evsubid = eventSubsribeNotification.InsertEvent_slm_subscribe(qstring, 1/*Convert.ToInt32(Context.User.Identity.GetUserId())*/, 1, true, false);

            if (IntranetCheck.Checked)
            {
                eventSubsribeNotification.InsertEvent_slm_subscribe_channel(evsubid, 1);
            }
            if (EmailCheckbox.Checked)
            {
                eventSubsribeNotification.InsertEvent_slm_subscribe_channel(evsubid, 2);
            }
            if (UnabotCheckBox.Checked)
            {
                eventSubsribeNotification.InsertEvent_slm_subscribe_channel(evsubid, 3);
            }
            if (SmsCheckBox.Checked)
            {
                eventSubsribeNotification.InsertEvent_slm_subscribe_channel(evsubid, 4);
            }
            for (int i = 0; i < UserListBox.Items.Count; i++)
            {
                if (UserListBox.Items[i].Selected)
                {
                    eventSubsribeNotification.InsertEvent_slm_subscribe_users(evsubid, UserListBox.Items[i].Value);
                }
            }



            Response.Redirect("Notifications.aspx");
        }

        protected void CancleButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Notifications.aspx");
        }

      

        protected void Adduser_Click1(object sender, EventArgs e)
        {
            Label1.Text = string.Empty;
            for (int i = 0; i < UserListBox.Items.Count; i++)
            {
                if (UserListBox.Items[i].Selected)
                {
                    Label1.Text += UserListBox.Items[i].ToString() + "  ";
                }
            }
        }
    }
}