namespace MpgsSharp.Models.HostedCheckout;

/// <summary>
///     Constants used for Hosted Checkout operations.
/// </summary>
public static class HostedCheckoutConstants
{
    /// <summary>
    ///     Operation types that can be performed after the Hosted Checkout interaction.
    /// </summary>
    public static class OperationType
    {
        /// <summary>
        ///     Creates an Authorization transaction for the payment.
        /// </summary>
        public const string Authorize = "AUTHORIZE";

        /// <summary>
        ///     Collects and stores payment details without performing any operation.
        /// </summary>
        public const string None = "NONE";

        /// <summary>
        ///     Creates a Purchase transaction for the payment.
        /// </summary>
        public const string Purchase = "PURCHASE";

        /// <summary>
        ///     Verifies the payer's account using the acquirer's verification method.
        /// </summary>
        public const string Verify = "VERIFY";
    }
}