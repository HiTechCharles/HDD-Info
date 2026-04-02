using System;
using System.Diagnostics;
using System.IO;
using BenchmarkDotNet.Attributes;
using Microsoft.VSDiagnostics;

namespace HDD_Info.Benchmarks
{
    [CPUUsageDiagnoser]
    public class HddInfoBenchmarks
    {
        private PerformanceCounter _cpuCounter;
        private PerformanceCounter _freeRamCounter;
        private PerformanceCounter _uptimeCounter;
        private DriveInfo _testDrive;
        private const double BYTES_TO_GB = 1024.0 * 1024.0 * 1024.0;
        [GlobalSetup]
        public void Setup()
        {
            // Initialize performance counters
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            _freeRamCounter = new PerformanceCounter("Memory", "Available MBytes");
            _uptimeCounter = new PerformanceCounter("System", "System Up Time");
            // Prime the counters
            _cpuCounter.NextValue();
            _freeRamCounter.NextValue();
            _uptimeCounter.NextValue();
            System.Threading.Thread.Sleep(100);
            // Get first available drive
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady)
                {
                    _testDrive = d;
                    break;
                }
            }
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _cpuCounter?.Dispose();
            _freeRamCounter?.Dispose();
            _uptimeCounter?.Dispose();
        }

        [Benchmark]
        public void PerformanceCounterReads()
        {
            float cpuVal = _cpuCounter.NextValue();
            double freeMemoryGB = _freeRamCounter.NextValue() / 1024.0;
            double uptime = _uptimeCounter.NextValue();
        }

        [Benchmark]
        public void DriveInfoOperations()
        {
            if (_testDrive != null && _testDrive.IsReady)
            {
                double freeSpaceGB = _testDrive.AvailableFreeSpace / BYTES_TO_GB;
                double totalSpaceGB = _testDrive.TotalSize / BYTES_TO_GB;
                double usedSpaceGB = (_testDrive.TotalSize - _testDrive.AvailableFreeSpace) / BYTES_TO_GB;
                double usedPercent = _testDrive.TotalSize > 0 ? 100.0 - ((double)_testDrive.AvailableFreeSpace / _testDrive.TotalSize * 100.0) : 0;
            }
        }

        [Benchmark]
        public string StringFormatting_Current()
        {
            double sizeInGB = 512.5;
            if (sizeInGB >= 1024)
                return $"{(sizeInGB / 1024.0):n2} TB";
            return $"{sizeInGB:n2} GB";
        }

        [Benchmark]
        public string UptimeFormatting_Current()
        {
            TimeSpan upTimeSpan = TimeSpan.FromSeconds(123456);
            return $"{(int)upTimeSpan.TotalDays} Days {upTimeSpan.Hours}H {upTimeSpan.Minutes}M {upTimeSpan.Seconds}S";
        }

        [Benchmark]
        public void GetDriveList()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            int readyCount = 0;
            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady)
                {
                    string display = $"{d.Name.TrimEnd('\\')} {d.VolumeLabel}";
                    readyCount++;
                }
            }
        }
    }
}