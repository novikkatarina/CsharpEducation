namespace Phonebook;

/// <summary>
/// Номер телефона.
/// </summary>
public class PhoneNumber
{
  protected bool Equals(PhoneNumber other)
  {
    return Number == other.Number && Type == other.Type;
  }

  public override bool Equals(object? obj)
  {
    if (ReferenceEquals(null, obj)) return false;
    if (ReferenceEquals(this, obj)) return true;
    if (obj.GetType() != this.GetType()) return false;
    return Equals((PhoneNumber)obj);
  }

  /// <summary>
  /// Значение номера телефона.
  /// </summary>
  public string Number { get; }

  /// <summary>
  /// Тип номера телефона.
  /// </summary>
  public PhoneNumberType Type { get; }

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="number">Значение номера телефона.</param>
  /// <param name="type">Тип номера телефона.</param>
  public PhoneNumber(string number, PhoneNumberType type)
  {
    this.Number = number;
    this.Type = type;
  }
}