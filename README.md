# Rave .NET SDK
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


# Payments
## Card Payments
This implements Card payments for Pin, 3D-Secure, VBV and PreAuth transactions.

## Usage
1. Pass Public and Secret keys as variables for configuration.
```
private static string PbKey = "pass your public key here"
private static string ScKey = "pass your secret key here"
```
