namespace Communication
{
    #region

    using System;

    #endregion

    /// <summary>
    ///   Interface for the Communication component. Provides methods for subscribing to, and broadcasting events. Events are identified by a unique string.
    /// </summary>
    public interface ICommunication
    {
        #region Public Methods

        /// <summary>
        ///   Broadcasts an event with a specified name and arguments.
        /// </summary>
        /// <typeparam name="T"> The type of the arguments for this event. </typeparam>
        /// <param name="eventName"> The name of the event that will be broadcasted. </param>
        /// <param name="args"> The arguments for this event. </param>
        void BroadcastEvent<T>(string eventName, T args) where T : EventArgs;

        /// <summary>
        ///   Subscribe to the event with the specified name. When an event with the specified name is broadcasted, the provided delegate will be called.
        /// </summary>
        /// <typeparam name="T"> The type of the arguments for this event. </typeparam>
        /// <param name="eventName"> The name of the event where the listener will be subscribed to. </param>
        /// <param name="listenerDelegate"> The delegate that will be called, when the event with the specified name is broadcasted. </param>
        void SubscribeToEvent<T>(string eventName, Communication.EventListener<T> listenerDelegate) where T : EventArgs;

        /// <summary>
        ///   Unsubscribe from the event with the specified name. When an event with the specified name is broadcasted, the provided delegate will no longer be called.
        /// </summary>
        /// <typeparam name="T"> The type of the arguments for this event. </typeparam>
        /// <param name="eventName"> The name of the event where the listener will be unsubscribed from. </param>
        /// <param name="listenerDelegate"> The delegate that will no longer be called, when the event with the specified name is broadcasted. </param>
        void UnSubscribeFromEvent<T>(string eventName, Communication.EventListener<T> listenerDelegate)
            where T : EventArgs;

        #endregion
    }
}