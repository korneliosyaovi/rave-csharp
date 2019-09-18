# Rave .NET SDK
## Description
The Rave .NET SDK makes it easy to add Rave support to your .NET web application and is built on Rave's REST APIs.

## Introduction
The Rave .NET Library implements the following payment services:

1. Card Payments
2. Bank Account Payments.
3. Mobile Money Payments.

The Library also implements the following features:
1. Tokeniztion (in development).
2. Subaccounts (in development).
3. Virtual Cards (in development).
4. Currencies.
5. Pre-Authorisation.
6. Refunds.

## Prerequisites
- .NET 4.5 or later

## Installation

## Configuration

1. Add all relevant modules
```
using System.Diagnostics;
using System.Collections.Generic;
using Rave.Models.MobileMoney;
using Rave.Models.VirtualCard;
using Rave.Models.Subaccount;
using Rave.Models;
using Rave.Models.Charge;
using Rave.Models.Account;
using Rave.Models.Card;
using Rave.Models.Validation;
using NUnit.Framework;
```

2. Pass Public and Secret keys as variables for configuration.
```
private static string PbKey = "pass your public key here"
private static string ScKey = "pass your secret key here"
var raveConfig = new RaveConfig(PbKey, SCKey, false);
```



# Payments
## Card Payments
This implements Card payments for Pin, 3D-Secure, VBV and PreAuth transactions.

## Usage
1. Complete basic configuration following the configuration steps.

2. Configure the card charge
```
var cardCharge = new ChargeCard(raveConfig);
```

3. Pass Card parameters as payload.
The payload should contain: 
- `Public key` 
- `First name`
- `Last name` 
- `Email address` 
- `Amount`
- `Card details.` 

These card details include:

- `Card number`
- `CVV`
- `Expiry month`
- `Expiry year`
- `Trans Ref`

```
`var Payload = new CardParams(PbKey, "Anonymous", "Customer", "tester@example.com", 2100){ cardNo = "5438898014560229", Cvv = "789", Expirymonth = "09", Expiryyear = "19", TxRef = tranxRef}
```

4. Charge card.
```
var cha = cardCharge.Charge(Payload).Result;
```

5. Pass Pin and OTP to complete the Transaction
```
 if (cha.Message == "AUTH_SUGGESTION" && cha.Data.SuggestedAuth == "PIN")
            {
                cardParams.Pin = "3310";
                cardParams.Otp = "12345";
                cardParams.SuggestedAuth = "PIN";
                cha = cardCharge.Charge(Payload).Result;
            }
```

6. Validate Transaction
```
Assert.IsNotNull(cha.Data);
            Assert.AreEqual("success", cha.Status);
            Validate.ValidateCardCharge(cha.Data.FlwRef);
```

**The complete card charge and validation flow:**
```
    class Program
    {
        private static string tranxRef = "454839";
        private static string PbKey = "";
        private static string ScKey = "";
        static void Main(string[] args)
        {
            
            var raveConfig = new RaveConfig(recurringPbKey, recurringScKey, false);
            var cardCharge = new CardCharge(raveConfig);

            var cardParams = new CardChargeParams(PbKey, "Anonymous", "Customer", "tester@example.com", 2100)
            { CardNo = "5438898014560229", Cvv = "789", Expirymonth = "09", Expiryyear = "19", TxRef = tranxRef }
            ;
            var cha = cardCharge.Charge(cardParams).Result;


            if (cha.Message == "AUTH_SUGGESTION" && cha.Data.SuggestedAuth == "PIN")
            {
                cardParams.Pin = "3310";
                cardParams.Otp = "12345";
                cardParams.SuggestedAuth = "PIN";
                cha = cardCharge.Charge(cardParams).Result;
            }


            Assert.IsNotNull(cha.Data);
            Assert.AreEqual("success", cha.Status);
            Validate.ValidateCardCharge(cha.Data.FlwRef);


        }
    }
    
    class Validate
    {
        private static string tranxRef = "454839";
        private static string PbKey = "";
        private static string ScKey = "";
        public static void ValidateCardCharge(string txRef)
        {
            var raveConfig = new RaveConfig(PbKey, ScKey, false);
            var cardValidation = new ValidateCardCharge(raveConfig);
            var val = cardValidation.ValidateCharge(new ValidateCardParams(PbKey, txRef, "12345")).Result;

            Trace.WriteLine($"Status: {val.Status}");
            Trace.WriteLine($"Message: {val.Message}");
            Assert.IsNotNull(val.Data);
            Assert.AreEqual("success", val.Status);

        }
    }
```

## Account Payments
This implements direct debit transactions from Bank accounts. 

## Usage
1. Complete basic configuration following the configuration steps.

2. Configure the Account charge
```
var accountCharge = new ChargeAccount(raveConfig);
```

3. Pass Account parameters as payload. The payload should contain: 
- `Public key` 
- `First name`
- `Last name` 
- `Email address`
- `Account number`
- `Amount`
- `Bank code.`
- `Trans Ref`

```
var Payload = new AccountParams(PbKey, "Anonymous", "customer", "user@example.com", "0690000031", 1000.00m, "044", "MC-0292920");
```

4. Charge Account.
```
var chargeResponse = await accountCharge.Charge(accountParams);

if (chargeResponse.Data.Status == "success-pending-validation")
{
      // This usually means the user needs to validate the transaction with an OTP
      accountParams.Otp = "12345";
      chargeResponse = accountCharge.Charge(accountParams).Result;
}

Trace.WriteLine(chargeResponse.Data.ValidateInstructions.Instruction);
Trace.WriteLine(chargeResponse.Data.ValidateInstructions.Valparams);
Trace.WriteLine(chargeResponse.Data.ValidateInstruction);
Assert.IsNotNull(chargeResponse.Data);
Assert.AreEqual("success", chargeResponse.Status);
            
```

5. Validate the Transacation
```
ValidateAccountCharge(chargeResponse.Data.FlwRef);
```
**The complete card charge and validation flow:**
```
class Program
    {
        private static string tranxRef = "454839";
        private static string PbKey = "";
        private static string ScKey = "";
        static void Main(string[] args)
        {
            
            var raveConfig = new RaveConfig(recurringPbKey, recurringScKey, false);
            var accountCharge = new ChargeAccount(raveConfig);

            var Payload = new AccountParams(PbKey, "Anonymous", "customer", "user@example.com", "0690000031", 1000.00m, "044", "MC-0292920");
            var chargeResponse = await accountCharge.Charge(accountParams);


            if (chargeResponse.Data.Status == "success-pending-validation")
            {
                // This usually means the user needs to validate the transaction with an OTP
                accountParams.Otp = "12345";
                chargeResponse = accountCharge.Charge(accountParams).Result;
            }


            Trace.WriteLine(chargeResponse.Data.ValidateInstructions.Instruction);
            Trace.WriteLine(chargeResponse.Data.ValidateInstructions.Valparams);
            Trace.WriteLine(chargeResponse.Data.ValidateInstruction);
            Assert.IsNotNull(chargeResponse.Data);
            Assert.AreEqual("success", chargeResponse.Status);
            ValidateAccountCharge(chargeResponse.Data.FlwRef);


        }
    }
    
    class Validate
    {
        private static string PbKey = "";
        private static string ScKey = "";
        private static string transRef = "Ref105";
        private static string sampleSuccessfulFwRef = "ACHG-1521196019857";
        public static void ValidateAccountCharge(string txRef)
        {
            var raveConfig = new RaveConfig(PbKey, ScKey, false);
            var accountValidation = new ValidateAccountCharge(raveConfig);
            var val = accountValidation.ValidateCharge(new ValidateAccountParams(PbKey, txRef, "12345")).Result;

            Trace.WriteLine($"Status: {val.Status}");
            Trace.WriteLine($"Message: {val.Message}");
            if (val.Status == "error")
            {
                var desiredResponses = new List<string> { "Transaction already complete", "TRANSACTION ALREADY VERIFIED" }; // These are also accepted values depending on whether the transaction has be verified before
                Assert.IsTrue(desiredResponses.Contains(val.Message));
            }
            else
            {
                Assert.IsNotNull(val.Data);
                Assert.AreEqual("success", val.Status);
                Assert.AreEqual("Charge Complete", val.Message);
            }

        }
    }
```

## Mobile Money Payments
This implements Mpesa, Ghana, Uganda, Zambia and Rwanda Mobile money transactions for customers.

## Usage
1. Complete basic configuration following the configuration steps.

2. Configure the Mobile money charge
```
var mobilemoney = new ChargeMobileMoney(raveConfig);
```

3. Pass mobile money parameters as payload. The payload should contain: 
- `Public key`
- `Secret key`
- `First name`
- `Last name` 
- `Email address`
- `Amount`
- `Currency`
- `Mobile number`
- `Network`
- `Country`
- `Payment Type`
- `Trans Ref`

```
var Payload = new MobileMoneyParams(PbKey, ScKey, "Anonymous", "customer", "user@example.com",  1055, "GHS", "054709929220", "network", "country", "paymentType", "MC-0292920");
```
The payload parameters differ for different countries, currencies and payment types.

| Country | Payment Type | Currency | Network |
| ------- | ------------ | -------- | ------- |
| Ghana `GH` | `mobilemoneygh` | GHS | `MTN, VODAFONE, TIGO` |
| Kenya `KE` | `mpesa` | KES |    
| Rwanda `NG` | `mobilemoneygh` | RWF | `RWF` |
| Uganda `UG` | `mobilemoneyuganda` | UGX | `UGX` |
| Zambia `NG` |  `mobilemoneyzambia` | ZMW | `MTN` |
## Support
For further assistance in using the SDK, you can contact the Developers on [Slack](https://join.slack.com/t/flutterwavedevelopers/shared_invite/enQtNTk3MjgxMjU3ODI5LWFkMjBkYTc0ZGJhM2Q5MTY3YjFkYzAyYmM1ZDZjZjUwMjE4YTc2NjQ1ZGM5ZWE4NDUxMzc4MmExYmI1Yjg5ZWU) and [Email](mailto:developers@flutterwavego.com). You can also check out some awesome Beta features [here](https://developer.flutterwave.com/reference#introduction). 
