using System;
using System.Runtime.Serialization;

namespace Ex03.GarageLogic
{
    public class ValueRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;
        private string m_ErrorMassage;
        public ValueRangeException(int i_maxValue, int i_minValue, string i_errorMassage)
        {
            this.m_MaxValue = i_maxValue;
            this.m_MinValue = i_minValue;
            this.m_ErrorMassage = i_errorMassage;
        }
        public ValueRangeException(float i_maxValue, float i_minValue, string i_errorMassage)
        {
            this.m_MaxValue = i_maxValue;
            this.m_MinValue = i_minValue;
            this.m_ErrorMassage = i_errorMassage;
        }
    }
}