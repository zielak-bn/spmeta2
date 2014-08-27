﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPMeta2.Regression.Services.Rnd
{
    public class DefaultRandomService : RandomService
    {
        private Random _rnd = new Random();

        public override Guid Guid()
        {
            return System.Guid.NewGuid();
        }

        public override string String()
        {
            return String(32);
        }

        public override string String(int lenght)
        {
            var iterations = (lenght / 32) + 1;

            var result = string.Empty;

            for (var i = 0; i < iterations; i++)
                result += System.Guid.NewGuid().ToString("N");

            return result.Substring(0, lenght);
        }

        public override int Int()
        {
            return Int(int.MaxValue);
        }

        public override int Int(int maxValue)
        {
            return _rnd.Next(maxValue);
        }

        public override double Double()
        {
            return Double(double.MaxValue);
        }

        public override double Double(double maxValue)
        {
            return _rnd.NextDouble() * maxValue;
        }

        private bool _boolFlag = false;

        public override bool Bool()
        {
            _boolFlag = !_boolFlag;

            return _boolFlag;
        }

        public override string UserLogin()
        {
            return string.Format("{0}/{1}", Environment.UserDomainName, Environment.UserName);
        }

        public override string UserEmail()
        {
            return string.Format("{0}@{0}.com", Environment.UserName);
        }

        public override string UserName()
        {
            return string.Format("{0}", Environment.UserName);
        }

        public override string ManagedPath()
        {
            return "sites";
        }
    }
}