namespace Communication
{
    #region

    using System;
    using System.Collections.Generic;
    
    #endregion

    /// <see cref="ICommunication" />
    public class Communication : ICommunication
    {
        #region Constants and Fields

        private Dictionary<string, List<Delegate>> _eventDict;

        #endregion

        #region Constructors and Destructors

        public Communication()
        {
            _eventDict = new Dictionary<string, List<Delegate>>();
        }

        #endregion

        #region Delegates

        public delegate void EventListener<T>(T args) where T : EventArgs;

        #endregion

        #region Public Methods

        /// <see cref="ICommunication.BroadcastEvent{T}" />
        public void BroadcastEvent<T>(string eventName, T args) where T : EventArgs
        {
            if (!_eventDict.ContainsKey(eventName))
            {
                // Early out if there are no listeners for this event.
                return;
            }

#if DEBUG
            //Debug.Log(String.Format("The event: {0} was broadcasted.", eventName));
#endif

            foreach (var d in _eventDict[eventName])
            {
                (d as EventListener<T>).Invoke(args);
            }
        }

        /// <see cref="ICommunication.SubscribeToEvent{T}" />
        public void SubscribeToEvent<T>(string eventName, EventListener<T> listenerDelegate) where T : EventArgs
        {
            if (_eventDict.ContainsKey(eventName))
            {
                _eventDict[eventName].Add(listenerDelegate);
            }
            else
            {
                _eventDict[eventName] = new List<Delegate>() { listenerDelegate };
            }
        }

        /// <see cref="ICommunication.UnSubscribeFromEvent{T}" />
        public void UnSubscribeFromEvent<T>(string eventName, EventListener<T> listenerDelegate) where T : EventArgs
        {
            if (_eventDict.ContainsKey(eventName))
            {
                _eventDict[eventName].Remove(listenerDelegate);
            }
        }

        #endregion
    }
}