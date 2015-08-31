namespace NelitaBeautyStudio.Common
{
    public static class GlobalConstants
    {
        public const string AdminRole = "Admin";

        public const string AddContact = "Успешно добавен контакт!";
        public const string EditContact = "Успешно редактиран контакт!";
        public const string DeleteContact = "Успешно изтрит контакт!";

        public const string AddPriceList = "Успешно добавен ценоразпис!";
        public const string EditPriceList = "Успешно редактиран ценоразпис!";
        public const string DeletePriceList = "Изтрит е ценоразписа и всички услуги записани в него!";

        public const string PromoteUser = "Потребителят е повишен като администратор!";
        public const string DemoteUserFail = "Не можете да понижите себе си!";
        public const string DemoteUserSuccess = "Потребителят е понижен!";

        public const string AddService = "Успешно добавена нова услуга!";
        public const string EditService = "Услугата е рекатирана успешно!";
        public const string DeleteService = "Услугата е изтрита!";

        public const int TextFieldLengthMax = 75;
        public const int TextFieldLengthMin = 6;
        public const int NewsIndexPageSize = 10;

        public const double PriceMinimum = 0.0;
        public const double PriceMaximum = 500.0;
    }
}
