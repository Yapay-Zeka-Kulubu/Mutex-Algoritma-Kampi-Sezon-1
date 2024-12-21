public class GetBorrowReqDTO{
    public int id {get;set;}
    public string userFullname{get;set;}
    public string bookTitle {get;set;}
    public DateOnly borrowDate {get;set;}
    public DateOnly returnDate {get;set;}
}