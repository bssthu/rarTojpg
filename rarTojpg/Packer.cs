using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace rarTojpg
{
    /// <summary>
    /// 文件打包进程的类
    /// </summary>
    class Packer
    {
        /// <summary>
        /// 每一轮操作的字节数
        /// </summary>
        public const int MaxBytes = 0x100000;      // 1MByte

        /// <summary>
        /// JPG文件流
        /// </summary>
        private FileStream fsSourceJpg;

        /// <summary>
        /// RAR文件流
        /// </summary>
        private FileStream fsSourceRar;

        /// <summary>
        /// 目标文件流
        /// </summary>
        private FileStream fsTarget;

        /// <summary>
        /// 两个源文件总长度
        /// </summary>
        private long length;

        /// <summary>
        /// 已完成的轮次
        /// </summary>
        private int round = 0;

        /// <summary>
        /// 估计速率
        /// </summary>
        private double estimatedSpeed;

        private Stopwatch stopwatch;

        /// <summary>
        /// 文件打包完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void PackFinishedDelegate(object sender, EventArgs e);

        /// <summary>
        /// 事件，
        /// 一轮操作完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void RoundFinishedDelegate(object sender, RoundFinishedEventArgs e);

        /// <summary>
        /// 文件打包完成
        /// </summary>
        public PackFinishedDelegate OnPackFinished;

        /// <summary>
        /// 事件，
        /// 一轮操作完成
        /// </summary>
        public RoundFinishedDelegate OnRoundFinished;


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="newFsSourceJpg">JPG文件流</param>
        /// <param name="newFsSourceRar">RAR文件流</param>
        /// <param name="newFsTarget">目标文件流</param>
        public Packer(FileStream newFsSourceJpg,
            FileStream newFsSourceRar, FileStream newFsTarget)
        {
            this.fsSourceJpg = newFsSourceJpg;
            this.fsSourceRar = newFsSourceRar;
            this.fsTarget = newFsTarget;
            this.length = newFsSourceJpg.Length + newFsSourceRar.Length;
            this.stopwatch = new Stopwatch();
        }

        /// <summary>
        /// 从一个文件流拷贝到另一个文件流
        /// </summary>
        /// <param name="fsSource">源文件流</param>
        /// <param name="fsTarget">目标文件流</param>
        private void fsCopyFile(FileStream fsSource, FileStream fsTarget)
        {
            long off = fsTarget.Position;
            if (fsSource.Length / MaxBytes >= 1)
            {
                byte[] bufMax = new byte[MaxBytes];
                for (int i = 0; i < fsSource.Length / MaxBytes; i++)
                {
                    fsSource.Read(bufMax, 0, MaxBytes);
                    fsSource.Flush();
                    fsTarget.Write(bufMax, 0, MaxBytes);
                    fsTarget.Flush();
                    fsTarget.Position = fsSource.Position + off;
                    round++;
                    if (i == 0)
                    {
                        estimatedSpeed = fsTarget.Position / stopwatch.Elapsed.TotalSeconds;
                    }
                    else
                    {
                        estimatedSpeed = 0.875 * estimatedSpeed +
                            0.125 * fsTarget.Position / stopwatch.Elapsed.TotalSeconds;
                    }
                    OnRoundFinished(this, new RoundFinishedEventArgs(
                        round, (int)estimatedSpeed,
                        (length - fsTarget.Position) / estimatedSpeed));
                }
            }
            int lastBytes = (int)(fsSource.Length % MaxBytes);
            byte[] bufLast = new byte[lastBytes];
            fsSource.Read(bufLast, 0, lastBytes);
            fsSource.Flush();
            fsTarget.Write(bufLast, 0, lastBytes);
            fsTarget.Flush();
        }

        public void ThreadStart()
        {
            stopwatch.Start();
            fsCopyFile(fsSourceJpg, fsTarget);
            fsCopyFile(fsSourceRar, fsTarget);
            stopwatch.Stop();
            OnPackFinished(this, null);
        }
    }
}
