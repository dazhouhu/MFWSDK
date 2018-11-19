namespace MFW.Core
{
    public enum CertificateChoiceType
    {
        NOT_TRUST = 0         /**< Do not trust the certificate. */
        ,TRUST_ONCE         /**< Trust the certificate only once. */
        ,TRUST_ALWAYS       /**< Always trust the certificate. */
    }
}
