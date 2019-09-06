using System;
using System.Collections.Generic;
using System.Text;

namespace Rave.config
{
    /// <summary>
    /// Constants that are used by Rave SDK
    /// </summary>
    public class Const
    {
        /// <summary>
        /// Live REST API endpoint
        /// </summary>
        public static String LIVE_URL = "https://api.ravepay.co/v2/services/confluence";

        /// <summary>
        /// Live REST API endpoint for capture
        /// </summary>
        public static String CAPTURE_URL = "https://api.ravepay.co/flwv3-pug/getpaidx/api/capture";

        /// <summary>
        /// Live REST API endpoint for void
        /// </summary>
        public static String VOID_URL = "https://api.ravepay.co/flwv3-pug/getpaidx/api/refundorvoid";

        /// <summary>
        /// GET Method for services
        /// </summary>
        public static String SERVICE_METHOD_GET = "get";

        /// <summary>
        /// POST Method for services
        /// </summary>
        public static String SERVICE_METHOD_POST = "post";

        /// <summary>
        /// Live REST API charging endpoint 
        /// </summary>
        public static String LIVE_CHARGE_URL = "https://api.ravepay.co/flwv3-pug/getpaidx/api/charge";

        /// <summary>
        /// Url for redirecting 
        /// </summary>
        public static String REDIRECT_URL = "";

        public static String alg = "3DES-24";

        /// <summary>
        /// Live REST API endpoint for querying list of existing subscriptions
        /// </summary>
        public static String SUSCRIPTION_LIST_URL = "https://api.ravepay.co/v2/gpx/subscriptions/query";

        /// <summary>
        /// Live REST API endpoint for subscription
        /// </summary>
        public static String SUSCRIPTION_URL = "https://api.ravepay.co/v2/gpx/subscriptions/";

        /// <summary>
        /// Live REST API endpoint for refunds
        /// </summary>
        public static String LIVE_REFUND_URL = "https://api.ravepay.co/gpx/merchant/transactions/refund";

        /// <summary>
        /// Live REST API endpoint for creating payment plans
        /// </summary>
        public static String PAYMENT_PLAN_CREATE_LIVE_URL = "https://api.ravepay.co/v2/gpx/paymentplans/create";

        /// <summary>
        /// Live REST API endpoint for querying list of existing payment plans
        /// </summary>
        public static String PAYMENT_PLAN_LIVE_URL = "https://api.ravepay.co/v2/gpx/paymentplans/query";

        /// <summary>
        /// Live REST API endpoint for deleting payment plans
        /// </summary>
        public static String PAYMENT_PLAN_CANCEL_LIVE_URL = "https://api.ravepay.co/v2/gpx/paymentplans/";

        /// <summary>
        /// Live REST API endpoint for quering BVN
        /// </summary>
        public static String BVN_LIVE = "https://api.ravepay.co/v2/kyc/bvn";

        /// <summary>
        /// Live REST API endpoint for creating virtual cards.
        /// </summary>
        public static String LIVE_VIRTUAL_CARD_CREATE_URL = "https://api.ravepay.co/v2/services/virtualcards/new";

        /// <summary>
        /// Live REST API endpoint for funding virtual cards.
        /// </summary>
        public static String LIVE_VIRTUAL_CARD_FUND_URL = "https://api.ravepay.co/v2/services/virtualcards/fund";

        /// <summary>
        /// Live REST API endpoint for paying bills
        /// </summary>
        public static String EBILLS_LIVE_URL = "https://api.ravepay.co/flwv3-pug/getpaidx/api/ebills/";

        /// <summary>
        /// Live REST API endpoint for paying bills
        /// </summary>
        public static String EBILLS_URL = "https://api.ravepay.co/flwv3-pug/getpaidx/api/ebills/";

        /// <summary>
        /// Live REST API endpoint for querying list of existing subaccounta
        /// </summary>
        public static String SUBACCOUNT_LIST_URL = "https://api.ravepay.co/v2/gpx/subaccounts";

        /// <summary>
        /// Live REST API endpoint for settlements
        /// </summary>
        public static String  SETTLEMENT_URL_LIVE = "https://ravesandboxapi.flutterwave.com/v2/merchant/settlements";

        /// <summary>
        /// Live REST API endpoint for verifying transactions
        /// </summary>
        public static String TRANSACTION_VERIFICATION_URL_LIVE = "https://api.ravepay.co/flwv3-pug/getpaidx/api/v2/verify";

        /// <summary>
        /// Live REST API endpoint for making transfers
        /// </summary>
        public static String TRANSFER_URL = "https://api.ravepay.co/v2/gpx/transfers/";

        /// <summary>
        /// Live REST API endpoint for validating card and account charges
        /// </summary>
        public static String VALIDATE_CHARGE_URL = "https://api.ravepay.co/flwv3-pug/getpaidx/api/validatecharge";

        /// <summary>
        /// Live REST API endpoint for tokenizing card and account charges
        /// </summary>
        public static String TOKENIZED_CHARGE_URL_LIVE = "https://api.ravepay.co/flwv3-pug/getpaidx/api/tokenized/charge";

        /// <summary>
        /// Live REST API endpoint for updating customer information after tokenization
        /// </summary>
        public static String TOKEN_UPDATE_URL_LIVE = "https://api.ravepay.co/flwv3-pug/getpaidx/api/tokenized/update_customer";

        /// <summary>
        /// Sevice version
        /// </summary>
        public static String SERVICE_VERSION = "v1";

        /// <summary>
        /// Service channel
        /// </summary>
        public static String SERVICE_CHANNEL = "rave";

        /// <summary>
        /// Billername for Airtime
        /// </summary>
        public static String AIRTIME_BILLERNAME = "AIRTIME";

        /// <summary>
        /// Billername for DSTV
        /// </summary>
        public static String DSTV_BILLERNAME = "DSTV";

        /// <summary>
        /// Billername for Box Office
        /// </summary>
        public static String DSTV_BOX_OFFICE_BILLERNAME = "DSTV BOX OFFICE";

        /// <summary>
        /// Buy Service 
        /// </summary>
        public static String BUY_SERVICE = "fly_buy";
    }
}
