using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineApp.Utility
{
    public class SD
    {
        public const string Proc_ApplicationType_Create = "usp_CreateApplicationType";
        public const string Proc_ApplicationType_Get = "usp_GetApplicationType";
        public const string Proc_ApplicationType_GetAll = "usp_GetApplicationTypes";
        public const string Proc_ApplicationType_Update = "usp_UpdateApplicationType";
        public const string Proc_ApplicationType_Delete = "usp_DeleteApplicationType";

        public const string Role_User_Indi = "Användare";
        //public const string Role_User_Comp = "Company Customer";
        public const string Role_Admin = "Admin";
        //public const string Role_Employee = "Anställd";

        public const string ssShoppingCart = "Shoping Cart Session";

        public const string StatusPending = "Kontrolleras";
        public const string StatusApproved = "Godkänd";
        public const string StatusInProcess = "Pågår";
        public const string StatusShipped = "Skickad";
        public const string StatusCancelled = "Avbruten";
        public const string StatusRefunded = "Återbetalat";

        public const string PaymentStatusPending = "Kontrolleras";
        public const string PaymentStatusApproved = "Godkänd";
        public const string PaymentStatusDelayedPayment = "ApprovedForDelayedPayment";
        public const string PaymentStatusRejected = "Avvisas";


        public static double GetPriceBasedOnQuantity(double quantity, double price)
        {
            if (quantity < 50)
            {
                return price;
            }
            else
            {
                if (quantity > 50)
                {
                    return price;
                }
                else
                {
                    return price;
                }
            }

        }
        public static string ConvertToRawHtml(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

    }
}
