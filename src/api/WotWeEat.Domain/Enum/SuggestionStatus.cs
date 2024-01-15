namespace WotWeEat.Domain.Enum;

public enum SuggestionStatus
{
    //A meal has been suggested by the application, user has not made a choice yet
    Suggested = 0,
    //A suggested meal has been denied by the user
    Denied = 1,
    //A suggested meal has been approved by the user, or a meal was entered manually by the user.
    Approved = 2
}