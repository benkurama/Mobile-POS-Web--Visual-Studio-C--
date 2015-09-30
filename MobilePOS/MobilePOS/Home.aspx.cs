using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libPOS.BLL;

//using PushSharp;
//using PushSharp.Core;
//using PushSharp.Android;
//using System.IO;
////////////////////////////////////////////////////////
// Created By Alvin B.Sison : Android/.net Programmer of
// Webtool & Mobile App
// @REDFOOTTECH via CELLPRIME CORPORATION
////////////////////////////////////////////////////////
namespace MobilePOS
{
    public partial class Home : System.Web.UI.Page
    {
        private void CallEmployeeLog()
        {
            gvEmployeeLog.DataSource = Employee.GetLoggedEmployee();
            gvEmployeeLog.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if(!IsPostBack){
                lblUser.Text = GlobalAccess.Fullname;
            }

            var collection = Event_Log.GetCurrentEvents();
            //
            var empList = collection.Where(o => o.TableName == "employee" && o.Event == "insert").ToList();
            int empCount = empList.Count;

            var kioskList = collection.Where(o => o.TableName == "kiosk" && o.Event == "insert").ToList();
            int kioskCount = kioskList.Count;

            var productList = collection.Where(o => o.TableName == "product" && o.Event == "insert").ToList();
            int productCount = productList.Count;

            var salesList = collection.Where(o => o.TableName == "salesinfo" && o.Event == "insert").ToList();
            int salesCount = salesList.Count;
            //
            lblEmployee.Text = string.Format("{0}({1})", "Employee", empCount);

            lblKiosk.Text = string.Format("{0}({1})", "Kiosk", kioskCount);

            lblItems.Text = string.Format("{0}({1})", "Items", productCount);

            lblSales.Text = string.Format("{0}({1})", "Sales", salesCount);
            ///
            CallEmployeeLog();
        }

        protected void ServerButton_Click(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "key", "launchModal();", true);
            (Master as Frame).PopUp("testing");
        }

        public void AlertBox(string msg)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert( '" + msg + "');", true);

        }

        //Currently it will raise only for android devices
        //void DeviceSubscriptionChanged(object sender,
        //string oldSubscriptionId, string newSubscriptionId, INotification notification)
        //{
        //    AlertBox("DeviceSubscriptionChanged");
        //}

        ////this even raised when a notification is successfully sent
        // void NotificationSent(object sender, INotification notification)
        //{
        //    AlertBox("NotificationSent");
        //}

        ////this is raised when a notification is failed due to some reason
        // void NotificationFailed(object sender,
        //INotification notification, Exception notificationFailureException)
        //{
        //    AlertBox("NotificationFailed");
        //}

        ////this is fired when there is exception is raised by the channel
        // void ChannelException
        //    (object sender, IPushChannel channel, Exception exception)
        //{
        //    AlertBox("ChannelException");
        //}

        ////this is fired when there is exception is raised by the service
        // void ServiceException(object sender, Exception exception)
        //{
        //    AlertBox("ServiceException");
        //}

        ////this is raised when the particular device subscription is expired
        // void DeviceSubscriptionExpired(object sender,
        //string expiredDeviceSubscriptionId,
        //    DateTime timestamp, INotification notification)
        //{
        //    AlertBox("DeviceSubscriptionExpired");
        //}

        ////this is raised when the channel is destroyed
        // void ChannelDestroyed(object sender)
        //{
        //    AlertBox("ChannelDestroyed");
        //}

        ////this is raised when the channel is created
        // void ChannelCreated(object sender, IPushChannel pushChannel)
        //{
        //    AlertBox("ChannelCreated");
        //}

        //protected void btnPush_Click(object sender, EventArgs e)
        //{

        //    //create the puchbroker object
        //    var push = new PushBroker();
        //    //Wire up the events for all the services that the broker registers
        //    push.OnNotificationSent += NotificationSent;
        //    push.OnChannelException += ChannelException;
        //    push.OnServiceException += ServiceException;
        //    push.OnNotificationFailed += NotificationFailed;
        //    push.OnDeviceSubscriptionExpired += DeviceSubscriptionExpired;
        //    push.OnDeviceSubscriptionChanged += DeviceSubscriptionChanged;
        //    push.OnChannelCreated += ChannelCreated;
        //    push.OnChannelDestroyed += ChannelDestroyed;

        //    //Create our push services broker
        //    try
        //    {

        //        //Registering the GCM Service and sending an Android Notification
        //        push.RegisterGcmService(new GcmPushChannelSettings("AIzaSyBu0xhHPbjxNfghPR0yLA9H7-1Y78y-dxk"));
        //        //Fluent construction of an Android GCM Notification
        //        //IMPORTANT: For Android you MUST use your own RegistrationId here that gets generated within your Android app itself!
        //        push.QueueNotification(new GcmNotification().ForDeviceRegistrationId("APA91bFx9EUpvqzn9gvWYnvIIzlynomnjOReGMzwyqZUfqWwxPiAi80Q7Y_hgWO-XoiamiELL69vOBdgiDgIaSnNt_fHJOD8X1oqnrTnUeyvazI0pS6tdM_1uVerbrfEbWrFDitXyR2FcuDIh7gJ6pH7GWasPEf0IQ")
        //                              .WithJson("{\"alert\":\"Hello World!\",\"badge\":7,\"sound\":\"sound.caf\"}"));
        //    }
        //    catch (Exception ee)
        //    {
                
        //        throw;
        //    }

        //    push.StopAllServices(waitForQueuesToFinish: true); 
        //}

    }
}