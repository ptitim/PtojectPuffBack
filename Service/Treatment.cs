using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;

namespace Service
{
    /// <summary>
    /// Transport information about the treatment of the request
    /// intended for clients
    /// </summary>
    public class Treatment
    {
        #region Properties

        /// <summary>
        /// List of fatal errors
        /// </summary>
        public List<TreatmentEvent> FatalErrors { get; private set; }

        /// <summary>
        /// List of errors
        /// </summary>
        public List<TreatmentEvent> Errors { get; private set; }

        /// <summary>
        /// List of warnings
        /// </summary>
        public List<TreatmentEvent> Warnings { get; private set; }

        /// <summary>
        /// List of info
        /// </summary>
        public List<TreatmentEvent> Info { get; private set; }

        /// <summary>
        /// List of object to return
        /// Json format
        /// </summary>
        public List<object> Objects { get; set; }

        #endregion

        #region Constructor

        public Treatment()
        {
            FatalErrors = new List<TreatmentEvent>();
            Errors = new List<TreatmentEvent>();
            Warnings = new List<TreatmentEvent>();
            Info = new List<TreatmentEvent>();
            
            Objects = new List<object>();
        }

        #endregion

        #region Add message with code

        /// <summary>
        /// Add a fatal error to treament with http code
        /// </summary>
        /// <param name="htttpcode"></param>
        /// <param name="message"></param>
        public void AddFatalErrorWithCode(HttpStatusCode htttpcode, string message = null)
        {
            var tre = new TreatmentEvent(MessagesType.FatalError, htttpcode, message);
            FatalErrors.Add(tre);
        }

        /// <summary>
        /// Add an error to treatment with http code
        /// </summary>
        /// <param name="htttpcode"></param>
        /// <param name="message"></param>
        public void AddErrorWithCode(HttpStatusCode htttpcode, string message = null)
        {
            var tre = new TreatmentEvent(MessagesType.Error, htttpcode, message);
            Errors.Add(tre);
        }

        public void AddWarning(HttpStatusCode httpcode, string message)
        {
            var tre = new TreatmentEvent(MessagesType.Warning, httpcode, message);
            Warnings.Add(tre);
        }

        public void AddInfoWithCode(HttpStatusCode httpcode, string message = null)
        {
            var tre = new TreatmentEvent(MessagesType.Info, httpcode, message);
            Info.Add(tre);
        }

        #endregion

        #region Add messages

        public void AddFatalError(string message)
        {
            FatalErrors.Add(new TreatmentEvent(MessagesType.FatalError, message));
        }


        public void AddError(string message)
        {
            Errors.Add(new TreatmentEvent(MessagesType.Error, message));
        }

        public void AddWarning(string message)
        {
            Warnings.Add(new TreatmentEvent(MessagesType.Warning, message));
        }

        public void AddInfo(string message)
        {
            Info.Add(new TreatmentEvent(MessagesType.Info, message));
        }

        #endregion

        #region Object gestion

        public void AddObject(object obj)
        {
            Objects.Add(obj);
        }

        public void ClearObject()
        {
            Objects = new List<object>();
        }

        #endregion
        
        #region Merge

        /// <summary>
        /// return a new Treatment, fusion of both treatment
        /// </summary>
        /// <param name="???"></param>
        /// <returns></returns>
        public Treatment Merge(Treatment tr)
        {
            var newTr = new Treatment();
            
            //merge fatal errors
            newTr.FatalErrors = FatalErrors.Union(tr.FatalErrors).ToList();
            
            // Merge errors
            newTr.Errors = this.Errors.Union(tr.Errors).ToList();

            // Merge Warnings
            newTr.Warnings = Warnings.Union(tr.Warnings).ToList();
            
            // Merge info
            newTr.Info = Info.Union(tr.Info).ToList();

            // Merge Objects
            newTr.Objects = Objects.Union(tr.Objects).ToList();
//            newTr.Objects = Treatment.MergeObjects(Objects, tr.Objects);
            
            return newTr;
        }

//        /// <summary>
//        /// Merge two json to make it coherent
//        /// </summary>
//        /// <param name="sourceA"></param>
//        /// <param name="sourceB"></param>
//        /// <returns></returns>
//        private static string MergeObjects(List<object> sourceA, List<object>sourceB)
//        {
//            var objectA = JsonConvert.DeserializeObject(sourceA);
//            var objectB = JsonConvert.DeserializeObject(sourceB);
//            var test = new List<object>() {objectA, objectB};
//
//            return JsonConvert.SerializeObject(test);
//        }
//        
        #endregion

        #region Check

        /// <summary>
        /// Check if no errors or no fatal errors
        /// </summary>
        /// <returns></returns>
        public bool IsSuccess()
        {
            return !FatalErrors.Any() && !Errors.Any();
        }

        /// <summary>
        /// Chack if no fatal errors
        /// </summary>
        /// <returns></returns>
        public bool HasFatalErrors()
        {
            return FatalErrors.Any();
        }

        /// <summary>
        /// Check if no errors
        /// </summary>
        /// <returns></returns>
        public bool HasErrors()
        {
            return Errors.Any();
        }

        /// <summary>
        /// Check if no warnings
        /// </summary>
        /// <returns></returns>
        public bool HasWarnings()
        {
            return Warnings.Any();
        }

        /// <summary>
        /// check if no info
        /// </summary>
        /// <returns></returns>
        public bool HasInfo()
        {
            return Info.Any();
        }

        #endregion
    }


    public class TreatmentEvent
    {
        #region Properties

        public string Message;

        public MessagesType Type;

        public HttpStatusCode HttpCode;

        #endregion

        #region Constructor

        public TreatmentEvent()
        {
        }

        public TreatmentEvent(MessagesType type, string message)
        {
            Message = message;
            Type = type;
        }

        public TreatmentEvent(MessagesType type, HttpStatusCode code, string message = null)
        {
            Type = type;
            HttpCode = code;
            Message = message;
        }

        #endregion

        #region Methods

        public void SetErrorCode(HttpStatusCode code)
        {
            HttpCode = code;
        }

        #endregion
    }

    /// <summary>
    /// Type of message for treatment
    /// </summary>
    public enum MessagesType
    {
        FatalError,
        Error,
        Warning,
        Info,
    }
}