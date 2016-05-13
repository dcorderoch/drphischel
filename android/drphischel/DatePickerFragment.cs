using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace drphischel
{
    public class DatePickerFragment : DialogFragment
    {
        private readonly Context context;
        private DateTime date;
        private readonly DatePickerDialog.IOnDateSetListener listener;

        public DatePickerFragment(Context context, DateTime date, DatePickerDialog.IOnDateSetListener listener)
        {
            this.context = context;
            this.date = date;
            this.listener = listener;
        }

        public override Dialog OnCreateDialog(Bundle savedState)
        {
            var dialog = new DatePickerDialog(context, listener, date.Year, date.Month - 1, date.Day);
            return dialog;
        }
    }
}