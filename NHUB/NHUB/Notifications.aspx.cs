﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Repository;

namespace NHUB
{
    public partial class Notifications : System.Web.UI.Page
    {
       
        AddNotificationRepository addNotificationRepository = new AddNotificationRepository();
        NotificationsRepository notificationsRepository = new NotificationsRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            notificationsRepository.getDetails();


            //if (Page.IsPostBack)
            //{


            if (Context.User.IsInRole("Super Admin"))
            {
                for (int Sourcecount = 0; Sourcecount < notificationsRepository.SourceList.Count; Sourcecount++)
                {

                    Label lb = new Label();
                    lb.Text = notificationsRepository.SourceList[Sourcecount].SourceName1 + "<br/>";
                    lb.ID = "count";
                    NotificationPlaceHolder.Controls.Add(lb);


                    DataTable dataEvenets = addNotificationRepository.GetEventData(notificationsRepository.SourceList[Sourcecount].SourceId).Tables[0];
                    for (int i = 0; i < dataEvenets.Rows.Count; i++)
                    {
                        Label Name = new Label();

                        Name.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + dataEvenets.Rows[i]["Name"] + "<br/>";
                        NotificationPlaceHolder.Controls.Add(Name);
                        Name.Width = 300;
                        HyperLink Edit = new HyperLink();
                        HyperLink delete = new HyperLink();
                        Edit.Text = "Edit";
                        Edit.Width = 200;
                        string qstr = dataEvenets.Rows[i]["Id"].ToString();
                        Edit.NavigateUrl = "EditEvent?Id=" + dataEvenets.Rows[i]["Id"];
                        NotificationPlaceHolder.Controls.Add(Edit);
                        delete.Text = "Delete" + "<br/>";
                        delete.NavigateUrl = "DeleteEvent?id=" + qstr;
                        NotificationPlaceHolder.Controls.Add(delete);

                    }

                }

            }

            //if (Context.User.IsInRole(""))
            //{
            
                for (int Sourcecount = 0; Sourcecount < notificationsRepository.SourceList.Count; Sourcecount++)
                {

                    Label lb = new Label();
                    lb.Text = notificationsRepository.SourceList[Sourcecount].SourceName1 + "<br/>";
                    lb.ID = "count";
                    NotificationPlaceHolder.Controls.Add(lb);
                    AddNotificationButton.Visible = false;

                    DataTable dataEvenets = addNotificationRepository.GetEventData(notificationsRepository.SourceList[Sourcecount].SourceId).Tables[0];
                    for (int i = 0; i < dataEvenets.Rows.Count; i++)
                    {
                        Label Name = new Label();

                        Name.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + dataEvenets.Rows[i]["Name"] + "<br/>";
                        NotificationPlaceHolder.Controls.Add(Name);
                        Name.Width = 300;
                        HyperLink Edit = new HyperLink();
                        HyperLink delete = new HyperLink();
                        Edit.Text = "Edit";
                        Edit.Width = 200;
                        string xxx = dataEvenets.Rows[i]["Id"].ToString();
                        Edit.NavigateUrl = "Notifications";
                        NotificationPlaceHolder.Controls.Add(Edit);
                        delete.Text = "UnSubscribe" + "<br/>";
                        delete.NavigateUrl = "Subscribe?id=" + xxx;
                        NotificationPlaceHolder.Controls.Add(delete);

                    }
                }
            //}

        }



            private void PopulateTreeView(DataTable dtParent, int parentId, TreeNode treeNode)
            {

            //foreach (DataRow row in dtParent.Rows)
            //{

            //    TreeNode child = new TreeNode
            //    {
            //        Text = row["Name"].ToString(),
            //        Value = row["Id"].ToString()
            //    };

            //    if (parentId == 0)
            //    {
            //        TreeView1.Nodes.Add(child);

            //        DataTable dtChild = addNotificationRepository.GetData("SELECT Id, Name FROM Event where sourceid=" + child.Value);
            //        PopulateTreeView(dtChild, int.Parse(child.Value), child);
            //    }
            //    else
            //    {
            //        treeNode.ChildNodes.Add(child);
            //        HyperLink edit = new HyperLink();
            //        edit.Text = "Edit";
            //        edit.NavigateUrl = "#?Id=" + child.Value;
            //        NotificationPlaceHolder.Controls.Add(edit);
            //        //TreeNode childedit = new TreeNode
            //        //{
            //        //    Text = row["edit"].ToString(),
            //        //    Value = row["Id"].ToString()
            //        //};
            //        //treeNode.ChildNodes.Add(childedit);
            //        //HyperLink delete = new HyperLink();
            //        //edit.Text = "Delete";
            //        //edit.NavigateUrl = "#?Id=" + child.Value;
            //        //TreeNode Childdelete = new TreeNode
            //        //{
            //        //    Text = row["Delete"].ToString(),
            //        //    Value = row["Id"].ToString()
            //        //};
            //        //treeNode.ChildNodes.Add(Childdelete);
            //    }
            //}
        }


        protected void AddNotificationButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEvent.aspx");
        }
    }
}