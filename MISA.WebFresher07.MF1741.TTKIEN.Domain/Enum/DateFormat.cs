namespace MISA.WebFresher07.MF1741.TTKIEN.Domain
{
    public enum DateFormat
    {
        /// <summary>
        /// ngày/tháng/năm
        /// </summary>
        dayMonthYear = 0,

        /// <summary>
        /// tháng/ngày/năm
        /// </summary>
        monthDayYear = 1,

        /// <summary>
        /// năm/ngày/tháng
        /// </summary>
        yearDayMonth = 2,

        /// <summary>
        /// năm/tháng/ngày
        /// </summary>
        yearMonthDay = 3,

        yearOnly,
    }
}
