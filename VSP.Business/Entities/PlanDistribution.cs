﻿using VSP.Business.Components;
using PensionConsultants.Data.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace VSP.Business.Entities
{
    public class PlanDistribution : DatabaseEntity
    {
        public Guid PlanId;
        public decimal Distribution;
        public DateTime AsOfDate;

        private static string _tableName = "PlanDistribution";

        public PlanDistribution()
            : base(_tableName)
        {

        }

        public PlanDistribution(Guid primaryKey)
            : base(_tableName, primaryKey)
        {
            RefreshMembers();
        }

        /// <summary>
        /// Registers the instance's members with the abstract class in order to perform database operations. Do not register members
        /// that exist within the abstract class (e.g. CreatedOn).
        /// </summary>
        protected override void RegisterMembers()
        {
            base.AddColumn("PlanId", this.PlanId);
            base.AddColumn("Distribution", this.Distribution);
            base.AddColumn("AsOfDate", this.AsOfDate);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.PlanId = (Guid)base.GetColumn("PlanId");
            this.Distribution = (decimal)base.GetColumn("Distribution");
            this.AsOfDate = (DateTime)base.GetColumn("AsOfDate");
        }

        public static DataTable GetActive()
        {
            string sql = @"SELECT * FROM " + _tableName + " WHERE StateCode = 0";
            return Access.VspDbAccess.ExecuteSqlQuery(sql);
        }

        public static DataTable GetInactive()
        {
            string sql = @"SELECT * FROM " + _tableName + " WHERE StateCode = 1";
            return Access.VspDbAccess.ExecuteSqlQuery(sql);
        }

        public static DataTable GetAssociated(Guid planId)
        {
            string sql = @"SELECT * FROM " + _tableName + " WHERE PlanId = \'" + planId.ToString() + "\'";
            return Access.VspDbAccess.ExecuteSqlQuery(sql);
        }
    }
}
