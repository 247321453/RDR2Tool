using System;
using System.Threading;
using System.Threading.Tasks;

namespace Common
{
    public static class UIThread
	{
		private static SynchronizationContext _UIThread;

		public static void Init() {
			if(_UIThread != null)
			{
				return;
			}
			_UIThread = SynchronizationContext.Current;
		}

		public static SynchronizationContext GetUIThread() {
			return _UIThread;
		}

		public static void Post(Action action) {
			if(action != null){
				_UIThread.Post(delegate (object state)
				               {
				               	action.Invoke();
				               }, null);
			}
		}

		public static void Run<T>(Func<T> task, Action<Exception, T> done)
		{
            Task.Run(() =>
            {
				T result = default;
                Exception LastError = null;
                try
                {
                    result = task.Invoke();
                }
                catch (Exception e)
                {
                    LastError = e;
                }
                Post(() =>
                {
					done.Invoke(LastError, result);
                });
            });
        }

        public static void Run(Action task, Action<Exception> done)
        {
            Task.Run(() =>
            {
                Exception LastError = null;
                try
                {
                    task.Invoke();
                }
                catch (Exception e)
                {
                    LastError = e;
                }
                Post(() =>
                {
                    done.Invoke(LastError);
                });
            });
        }

        public static AsyncTask RunEx<T>(Func<AsyncTask, T> task, Action<Exception, T> done)
        {
            var cancelObj = new AsyncTask();
            Task.Run(() =>
            {
                T result = default;
                Exception LastError = null;
                try
                {
                    result = task.Invoke(cancelObj);
                }
                catch (Exception e)
                {
                    LastError = e;
                }
                Post(() =>
                {
                    done.Invoke(LastError, result);
                });
            });
            return cancelObj;
        }

        public static AsyncTask RunEx(Action<AsyncTask> task, Action<Exception> done)
        {
            var cancelObj = new AsyncTask();
            Task.Run(() =>
            {
                Exception LastError = null;
                try
                {
                    task.Invoke(cancelObj);
                }
                catch (Exception e)
                {
                    LastError = e;
                }
                Post(() =>
                {
                    cancelObj.IsCompleted = true;
                    done.Invoke(LastError);
                });
            });
            return cancelObj;
        }
    }

    public class AsyncTask
    {
        public bool IsCompleted { get; set; }
        private bool IsCancel;
        public void Cancel()
        {
            lock (this)
            {
                IsCancel = true;
            }
        }
        public bool IsCanceled()
        {
            lock (this)
            {
                return IsCancel;
            }
        }
    }
}
