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
    public class PlanAdvisorFee : DatabaseEntity
    {
        public Guid PlanAdvisorId;
        public decimal? Fee;
        public decimal? Benchmark25Fee;
        public decimal? Benchmark50Fee;
        public decimal? Benchmark75Fee;
        public bool RevenueSharingPaid;
        public bool ForfeituresPaid;
        public bool ParticipantsPaid;
        public bool PlanSponsorPaid;
        public DateTime? AsOfDate;
        public string Notes;
        public string Name;

        private static string _tableName = "PlanAdvisorFee";

        public PlanAdvisorFee()
            : base(_tableName)
        {

        }

        public PlanAdvisorFee(Guid primaryKey)
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
            base.AddColumn("PlanAdvisorId", this.PlanAdvisorId);
            base.AddColumn("Fee", this.Fee);
            base.AddColumn("Benchmark25Fee", this.Benchmark25Fee);
            base.AddColumn("Benchmark50Fee", this.Benchmark50Fee);
            base.AddColumn("Benchmark75Fee", this.Benchmark75Fee);
            base.AddColumn("RevenueSharingPaid", this.RevenueSharingPaid);
            base.AddColumn("ForfeituresPaid", this.ForfeituresPaid);
            base.AddColumn("ParticipantsPaid", this.ParticipantsPaid);
            base.AddColumn("PlanSponsorPaid", this.PlanSponsorPaid);
            base.AddColumn("AsOfDate", this.AsOfDate);
            base.AddColumn("Notes", this.Notes);
            base.AddColumn("Name", this.Name);
        }

        /// <summary>
        /// Resets the values of all public members to their values in the database.
        /// </summary>
        protected override void SetRegisteredMembers()
        {
            this.PlanAdvisorId = (Guid)base.GetColumn("PlanAdvisorId");
            this.Fee = (decimal?)base.GetColumn("Fee");
            this.Benchmark25Fee = (decimal?)base.GetColumn("Benchmark25Fee");
            this.Benchmark50Fee = (decimal?)base.GetColumn("Benchmark50Fee");
            this.Benchmark75Fee = (decimal?)base.GetColumn("Benchmark75Fee");
            this.RevenueSharingPaid = (System.Data.SqlTypes.SqlBoolean)base.GetColumn("RevenueSharingPaid") ? true : false;
            this.ForfeituresPaid = (System.Data.SqlTypes.SqlBoolean)base.GetColumn("ForfeituresPaid") ? true : false;
            this.ParticipantsPaid = (System.Data.SqlTypes.SqlBoolean)base.GetColumn("ParticipantsPaid") ? true : false;
            this.PlanSponsorPaid = (System.Data.SqlTypes.SqlBoolean)base.GetColumn("PlanSponsorPaid") ? true : false;
            this.AsOfDate = (DateTime?)base.GetColumn("AsOfDate");
            this.Notes = (string)base.GetColumn("Notes");
            this.Name = (string)base.GetColumn("Name");
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

        public static DataTable GetAssociatedActive(PlanAdvisor planAdvisor)
        {
            string sql = @"SELECT * FROM " + _tableName + " WHERE StateCode = 0 AND PlanAdvisorId = \'" + planAdvisor.Id.ToString() + "\'";
            return Access.VspDbAccess.ExecuteSqlQuery(sql);
        }

        public static DataTable GetAssociatedInactive(PlanAdvisor planAdvisor)
        {
            string sql = @"SELECT * FROM " + _tableName + " WHERE StateCode = 1 AND PlanAdvisorId = \'" + planAdvisor.Id.ToString() + "\'";
            return Access.VspDbAccess.ExecuteSqlQuery(sql);
        }
    }
}
