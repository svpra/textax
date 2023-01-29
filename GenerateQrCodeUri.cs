private string GenerateQrCodeUri(string email, string unformattedKey)
{
    return string.Format(
        AuthenticatorUriFormat,
        _urlEncoder.Encode("AppForAhahAndHehe"),
        _urlEncoder.Encode(email),
        unformattedKey);
}
