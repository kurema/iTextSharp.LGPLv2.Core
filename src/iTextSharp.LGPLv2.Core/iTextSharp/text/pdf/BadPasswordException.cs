namespace iTextSharp.text.pdf;

public class BadPasswordException : IOException
{
	public BadPasswordException(string message) : base(message)
	{
	}

	public BadPasswordException()
	{
	}

	public BadPasswordException(string message, Exception innerException) : base(message, innerException)
	{
	}

	public BadPasswordException(string message, Func<byte[], PasswordTestResult> tester) : this(message)
	{
		this.Tester = tester;
	}

	public PasswordTestResult? TryPassword(byte[] password)
	{
		if (Tester is null) return null;
		return Tester.Invoke(password);
	}
	public bool CanTryPassword { get { return Tester != null; } }

	internal Func<byte[], PasswordTestResult> Tester { get; }

	public enum PasswordTestResult
	{
		SuccessOwnerPassword, SuccessUserPassword, Fail,
	}
}
