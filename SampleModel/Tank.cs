using SampleModel.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModel
{
    public class Tank
    {
        private ComplexBlock Block;
        private GainBlock kx1;
        private GainBlock kx2;
        private GainBlock kx3;
        private double y1 = 10;
        private double y = 0;
        private LimitBlock xLimit = new LimitBlock(0, 100);
        private double dt = 0.1;
        public Tank(double dt)
        {
            this.dt = dt;
            kx1 = new GainBlock(1);
            kx2 = new GainBlock(-1);
            kx3 = new GainBlock(-1);


            Block = new ComplexBlock();

            Block.Add(new LimitedIntBlock(dt, 0, 100));
        }

        public double Calc(double x1, double x2)
        {
            x2 = xLimit.Calc(x2);
            x1 = xLimit.Calc(x1);
            double x = (y >= y1 - 0.5) ? kx1.Calc(x1) + kx2.Calc(x2) + kx3.Calc(1) : kx1.Calc(x1) + kx2.Calc(x2);
            y = Block.Calc(x);
            return y;
        }
    }
}
