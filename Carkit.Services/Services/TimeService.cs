using Carkit.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Services.Services
{
    public interface ITimeService
    {
        /// <summary>
        /// Получение доступного времени для заказа.
        /// </summary>
        List<string> GetPeriodForDay(List<Order> orders);
    }

    public class TimeService : ITimeService
    {
        /// <summary>
        /// Шаг в минутах. (1 - 60)
        /// </summary>
        public const int Step = 15;

        private const int StartHours = 10;
        private const int EndHours = 20;

        private int[] GetEmptyPeriod()
        {
            int[] period = new int[(60 / Step) * 24];

            for (int i = 0; i < period.Length; i++)
            {
                period[i] = 0;
            }

            return period;
        }

        /// <summary>
        /// Получение доступного времени для заказа.
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public List<string> GetPeriodForDay(List<Order> orders)
        {
            int[] arr = GetEmptyPeriod();

            if (orders != null && orders.Count > 0)
            {
                foreach(var order in orders)
                {
                    arr = GetPeriodForOrder(arr, order.Date, order.TimePeriod);
                }
            }

            return ConvertPeriodForTimeString(arr);
        }

        private List<string> ConvertPeriodForTimeString(int[] arr)
        {
            DateTime date = DateTime.Now;
            date = date.Date;
            List<string> times = new List<string>();

            int start = (60 / Step) * StartHours;
            int end = (60 / Step) * EndHours;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0 && i >= start && i <= end)
                {
                    times.Add(date.ToShortTimeString());
                }
                date = date.AddMinutes(Step);
            }

            return times;
        }

        private int[] GetPeriodForOrder(int[] period, DateTime date, double time)
        {
            int[] arr = Copy(period);

            int index = ConvertStartTime(date);
            int workPeriod = ConvertWorkPeriodTime(time);

            for (int i = index; i < index + workPeriod; i++)
            {
                arr[i] = 1;
            }

            return arr;
        }

        private int ConvertWorkPeriodTime(double time)
        {
            return (int)(time * 60) / Step;
        }

        private int ConvertStartTime(DateTime date)
        {
            return (date.Hour * 60 + date.Minute) / Step;
        }

        private int[] Copy(int[] arr)
        {
            int[] newArr = new int[arr.Length];
            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[i] = arr[i];
            }

            return newArr;
        }

    }
}
