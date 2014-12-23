using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rarTojpg
{
    class RoundFinishedEventArgs : EventArgs
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="round">已完成的轮次</param>
        /// <param name="speed">平均速度，字节/秒</param>
        /// <param name="timeLeft">预计剩余时间，秒</param>
        public RoundFinishedEventArgs(int round, int speed, double timeLeft)
        {
            this.round = round;
            this.speed = speed;
            this.timeLeft = timeLeft;
        }

        /// <summary>
        /// 已完成的轮次
        /// </summary>
        public readonly int round;

        /// <summary>
        /// 平均速度，字节/秒
        /// </summary>
        public readonly int speed;

        /// <summary>
        /// 预计剩余时间，秒
        /// </summary>
        public readonly double timeLeft;
    }
}