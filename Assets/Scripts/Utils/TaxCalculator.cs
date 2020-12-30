using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxCalculator
{
    /// <summary>
    /// 获取经过 years年，每一年的本息
    /// </summary>
    /// <param name="principle">本金</param>
    /// <param name="interestRate">年利率</param>
    /// <param name="years">经过的年份</param>
    public static void GetPrincipleAndInterest(float principle, float interestRate, int years)
    {
        var total = principle;
        for (var i = 0; i < years; i++)
        {
            total += total * interestRate;
            Debug.Log($"第{i + 1}年本息：{total}");
        }
    }

    /// <summary>
    /// 获取本息翻 "time" 倍需要的年数
    /// </summary>
    /// <param name="interestRate">年利率</param>
    /// <param name="time">翻倍数</param>
    public static void GetYearsByInterestRateAndTime(float interestRate, int time)
    {
        var total = 1f;
        var years = 0;
        while (true)
        {
            total += total * interestRate;
            years++;
            if (total >= time)
            {
                break;
            }
        }

        Debug.Log($"经过{years}年后，本息翻{time}倍或以上");
    }
}