
namespace KNBManagement.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using KNBManagement.Web;
    using KNBManagement.Web.Services.Core;


    // Implements application logic using the KN_BManageEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class KN_BManageService : LinqToEntitiesDomainService<KN_BManageEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'BusinessTypes' query.
        public IQueryable<BusinessType> GetBusinessTypes()
        {
            return this.ObjectContext.BusinessTypes
                .OrderBy(d => d.Name);
        }

        public IQueryable<BusinessType> GetBusinessTypesByBusinessTypeID(global::System.Guid businessTypeID)
        {
            return this.ObjectContext.BusinessTypes
                .Where(d => d.BusinessTypeID == businessTypeID)
                .OrderBy(d => d.Name);
        }

        public void InsertBusinessType(BusinessType businessType)
        {
            if ((businessType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(businessType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.BusinessTypes.AddObject(businessType);
            }
        }

        public void UpdateBusinessType(BusinessType currentBusinessType)
        {
            this.ObjectContext.BusinessTypes.AttachAsModified(currentBusinessType);
        }

        public void DeleteBusinessType(BusinessType businessType)
        {
            if ((businessType.EntityState == EntityState.Detached))
            {
                this.ObjectContext.BusinessTypes.Attach(businessType);
            }
            this.ObjectContext.BusinessTypes.DeleteObject(businessType);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Companies' query.
        public IQueryable<Company> GetCompanies()
        {
            return this.ObjectContext.Companies.OrderBy(d => d.CompanyName);
        }

        public void InsertCompany(Company company)
        {
            if ((company.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(company, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Companies.AddObject(company);
            }
        }

        public void UpdateCompany(Company currentCompany)
        {
            this.ObjectContext.Companies.AttachAsModified(currentCompany, this.ChangeSet.GetOriginal(currentCompany));
        }

        public void DeleteCompany(Company company)
        {
            if ((company.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Companies.Attach(company);
            }
            this.ObjectContext.Companies.DeleteObject(company);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Employees' query.
        public IQueryable<Employee> GetEmployees()
        {
            return this.ObjectContext.Employees.OrderBy(d => d.EmployeeName);
        }

        public IQueryable<Employee> GetEmployeesByCompanyID(global::System.Guid companyID)
        {
            return this.ObjectContext.Employees
                .Where(d => d.CompanyID == companyID)
                .OrderBy(d => d.EmployeeName);
        }

        public void InsertEmployee(Employee employee)
        {
            if ((employee.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(employee, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Employees.AddObject(employee);
            }
        }

        public void UpdateEmployee(Employee currentEmployee)
        {
            this.ObjectContext.Employees.AttachAsModified(currentEmployee);
        }

        public void DeleteEmployee(Employee employee)
        {
            if ((employee.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Employees.Attach(employee);
            }
            this.ObjectContext.Employees.DeleteObject(employee);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Journal' query.
        public IQueryable<Journal> GetJournal()
        {
            return this.ObjectContext.Journal.OrderByDescending(d => d.TradingDate);
        }

        public void InsertJournal(Journal journal)
        {
            if ((journal.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(journal, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Journal.AddObject(journal);
            }
        }

        public void UpdateJournal(Journal currentJournal)
        {
            this.ObjectContext.Journal.AttachAsModified(currentJournal, this.ChangeSet.GetOriginal(currentJournal));
        }

        public void DeleteJournal(Journal journal)
        {
            if ((journal.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Journal.Attach(journal);
            }
            this.ObjectContext.Journal.DeleteObject(journal);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'JournalDetail' query.
        public IQueryable<JournalDetail> GetJournalDetail()
        {
            return this.ObjectContext.JournalDetail
                .OrderBy(d => d.CompanyID)
                .OrderBy(d => d.JournalID)
                .OrderBy(d => d.JournalDetailID);
        }

        public void InsertJournalDetail(JournalDetail journalDetail)
        {
            if ((journalDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(journalDetail, EntityState.Added);
            }
            else
            {
                this.ObjectContext.JournalDetail.AddObject(journalDetail);
            }
        }

        public void UpdateJournalDetail(JournalDetail currentJournalDetail)
        {
            this.ObjectContext.JournalDetail.AttachAsModified(currentJournalDetail, this.ChangeSet.GetOriginal(currentJournalDetail));
        }

        public void DeleteJournalDetail(JournalDetail journalDetail)
        {
            if ((journalDetail.EntityState == EntityState.Detached))
            {
                this.ObjectContext.JournalDetail.Attach(journalDetail);
            }
            this.ObjectContext.JournalDetail.DeleteObject(journalDetail);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'JournalItemBizs' query.
        public IQueryable<JournalItemBiz> GetJournalItemBizs()
        {
            return this.ObjectContext.JournalItemBizs.OrderBy(d => d.JournalName);
        }

        public IQueryable<JournalItemBiz> GetJournalItemBizsByBusinessTypeID(global::System.Guid businessTypeID)
        {
            return this.ObjectContext.JournalItemBizs
                .Where(d => d.BusinessTypeID == businessTypeID)
                .OrderBy(d => d.JournalName);
        }

        public IQueryable<JournalItemBiz> GetJournalItemBizsByBusinessTypeIDForListDisplay(global::System.Guid businessTypeID)
        {
            var ent = this.GetJournalItemBizsByBusinessTypeID(businessTypeID);

            var lst = new List<JournalItemBiz>() { new JournalItemBiz() { JournalName = "（なし）" } };

            lst.AddRange(ent);

            return new EnumerableQuery<JournalItemBiz>(lst);
        }

        public void InsertJournalItemBiz(JournalItemBiz journalItemBiz)
        {
            if ((journalItemBiz.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(journalItemBiz, EntityState.Added);
            }
            else
            {
                this.ObjectContext.JournalItemBizs.AddObject(journalItemBiz);
            }
        }

        public void UpdateJournalItemBiz(JournalItemBiz currentJournalItemBiz)
        {
            this.ObjectContext.JournalItemBizs.AttachAsModified(currentJournalItemBiz);
        }

        public void DeleteJournalItemBiz(JournalItemBiz journalItemBiz)
        {
            if ((journalItemBiz.EntityState == EntityState.Detached))
            {
                this.ObjectContext.JournalItemBizs.Attach(journalItemBiz);
            }
            this.ObjectContext.JournalItemBizs.DeleteObject(journalItemBiz);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'JournalItemComps' query.
        public IQueryable<JournalItemComp> GetJournalItemComps()
        {
            return this.ObjectContext.JournalItemComps
                .OrderBy(d => d.CompanyID)
                .OrderBy(d => d.JournalName);
        }

        public void InsertJournalItemComp(JournalItemComp journalItemComp)
        {
            if ((journalItemComp.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(journalItemComp, EntityState.Added);
            }
            else
            {
                this.ObjectContext.JournalItemComps.AddObject(journalItemComp);
            }
        }

        public void UpdateJournalItemComp(JournalItemComp currentJournalItemComp)
        {
            this.ObjectContext.JournalItemComps.AttachAsModified(currentJournalItemComp);
        }

        public void DeleteJournalItemComp(JournalItemComp journalItemComp)
        {
            if ((journalItemComp.EntityState == EntityState.Detached))
            {
                this.ObjectContext.JournalItemComps.Attach(journalItemComp);
            }
            this.ObjectContext.JournalItemComps.DeleteObject(journalItemComp);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Slips' query.
        /// <summary>
        /// 伝票情報を取得します
        /// </summary>
        /// <returns></returns>
        public IQueryable<Slip> GetSlips()
        {
            return this.ObjectContext.Slips
                .OrderBy(d => d.CompanyID)
                .OrderByDescending(d => d.TradingDate);
        }

        public IQueryable<Slip> GetSlipsByCompanyIDTradingMonthry(global::System.Guid companyID, DateTime monthry)
        {
            var fromDate = new DateTime(monthry.Year, monthry.Month, 1);
            var toDate = fromDate.AddMonths(1);

            return this.ObjectContext.Slips
                .Where(d => d.CompanyID == companyID && (d.TradingDate) >= fromDate && (d.TradingDate) < toDate)
                //.OrderBy(d => d.CompanyID)
                .OrderByDescending(d => d.TradingDate);
        }

        public IQueryable<Slip> GetSlipsByCompanyIDTradingFromTo(global::System.Guid companyID, DateTime from, DateTime to)
        {
            var wkTo = to.AddDays(1);
            return this.ObjectContext.Slips
                .Where(d => d.CompanyID == companyID && (d.TradingDate) >= from && (d.TradingDate) < wkTo)
                //.OrderBy(d => d.CompanyID)
                .OrderByDescending(d => d.TradingDate);
        }

        //public IQueryable<Slip> GetSlipsByCompanyIDTradingDateForAdd(global::System.Guid companyID, DateTime tradingDate)
        //{
        //    return new EnumerableQuery<Slip>(new List<Slip> { new Slip {
        //        CompanyID = companyID,
        //        SlipID = global::System.Guid.NewGuid(),
        //        TradingDate = tradingDate
        //    } });
        //}

        public void InsertSlip(Slip slip)
        {
            if ((slip.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(slip, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Slips.AddObject(slip);
            }
        }

        public void UpdateSlip(Slip currentSlip)
        {
            this.ObjectContext.Slips.AttachAsModified(currentSlip);
        }

        public void DeleteSlip(Slip slip)
        {
            if ((slip.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Slips.Attach(slip);
            }
            this.ObjectContext.Slips.DeleteObject(slip);
        }



        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SlipDetails' query.
        /// <summary>
        /// 伝票詳細情報を取得します
        /// </summary>
        /// <returns></returns>
        public IQueryable<SlipDetail> GetSlipDetails()
        {
            return this.ObjectContext.SlipDetails
                .OrderBy(d => d.CompanyID)
                .OrderBy(d => d.SlipID)
                .OrderBy(d => d.DetailOrder);
        }

        /// <summary>
        /// 伝票詳細情報を返します。
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="slipID"></param>
        /// <returns></returns>
        public IQueryable<SlipDetail> GetSlipDetailsByCompanyIDSlipID(global::System.Guid companyID, global::System.Guid slipID)
        {
            return this.ObjectContext.SlipDetails
                .Where(d => d.CompanyID == companyID && d.SlipID == slipID)
                //.OrderBy(d => d.CompanyID)
                //.OrderBy(d => d.SlipID)
                .OrderBy(d => d.DetailOrder);
        }

        /// <summary>
        /// 伝票詳細情報を返します。ただし、レコードが存在しない場合は空の情報を挿入して返します。
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="slipID"></param>
        /// <returns></returns>
        public IQueryable<SlipDetail> GetSlipDetailsByCompanyIDSlipIDDefault(global::System.Guid companyID, global::System.Guid slipID)
        {
            var ent = this.GetSlipDetailsByCompanyIDSlipID(companyID, slipID);

            if (ent.Count() > 0)
            {
                return ent;
            }
            else
            {
                var newEnt = new List<SlipDetail>();
                return ent.Concat(newEnt);
            }
        }

        //public IQueryable<SlipDetail> GetSlipDetailsByCompanyIDSlipIDForAdd(global::System.Guid companyID, global::System.Guid slipID)
        //{
        //    return new EnumerableQuery<SlipDetail>(new List<SlipDetail> { new SlipDetail {
        //        CompanyID = companyID,
        //        SlipID = global::System.Guid.NewGuid(),
        //        SlipDetailID = global::System.Guid.NewGuid()
        //    } });
        //}


        public void InsertSlipDetail(SlipDetail slipDetail)
        {
            if ((slipDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(slipDetail, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SlipDetails.AddObject(slipDetail);
            }
        }

        public void UpdateSlipDetail(SlipDetail currentSlipDetail)
        {
            this.ObjectContext.SlipDetails.AttachAsModified(currentSlipDetail);
        }

        public void DeleteSlipDetail(SlipDetail slipDetail)
        {
            if ((slipDetail.EntityState == EntityState.Detached))
            {
                this.ObjectContext.SlipDetails.Attach(slipDetail);
            }
            this.ObjectContext.SlipDetails.DeleteObject(slipDetail);
        }


        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SlipTypes' query.
        /// <summary>
        /// 伝票種別を取得します
        /// </summary>
        /// <returns></returns>
        public IQueryable<SlipType> GetSlipTypes()
        {
            return this.ObjectContext.SlipTypes
                .OrderBy(d => d.SlipTypeID);
        }

        public void InsertSlipType(SlipType slipType)
        {
            if ((slipType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(slipType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SlipTypes.AddObject(slipType);
            }
        }

        public void UpdateSlipType(SlipType currentSlipType)
        {
            this.ObjectContext.SlipTypes.AttachAsModified(currentSlipType);
        }

        public void DeleteSlipType(SlipType slipType)
        {
            if ((slipType.EntityState == EntityState.Detached))
            {
                this.ObjectContext.SlipTypes.Attach(slipType);
            }
            this.ObjectContext.SlipTypes.DeleteObject(slipType);
        }

        //public IQueryable<JournalItem> GetJournalItems(global::System.Guid companyID)
        //{
        //    var company = this.ObjectContext.Companies
        //        .Where(d => d.CompanyID == companyID)
        //        .SingleOrDefault();

        //    var journalItemBizs = this.ObjectContext.JournalItemBizs
        //        .Where(d => d.BusinessTypeID == company.BusinessTypeID)
        //        .Select<JournalItemBiz, JournalItem>(d => new JournalItem{  } )
        //        //.OrderBy(d => d.JournalName)
        //        ;

        //    var jounalItemComp = this.ObjectContext.JournalItemComps
        //        .Where(d => d.CompanyID == companyID)
        //        //.OrderBy(d => d.JournalName)
        //        ;

        //    //return this.ObjectContext.j
        //    return null;
        //}
    }
}


