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
2. Subaccounts.
3. Virtual Cards.
4. Currencies.

## Prerequisites
- .NET 4.0 or later

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
var cardCharge = new CardCharge(raveConfig);
```

3. Pass Card parameters as payload.
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


## Support
For further assistance in using the SDK, you can contact the Developers on [Slack](https://join.slack.com/t/flutterwavedevelopers/shared_invite/enQtNTk3MjgxMjU3ODI5LWFkMjBkYTc0ZGJhM2Q5MTY3YjFkYzAyYmM1ZDZjZjUwMjE4YTc2NjQ1ZGM5ZWE4NDUxMzc4MmExYmI1Yjg5ZWU) and [Email](developers@flutterwavego.com). You can also check out some awesome Beta features [here](https://developer.flutterwave.com/reference#introduction). 
