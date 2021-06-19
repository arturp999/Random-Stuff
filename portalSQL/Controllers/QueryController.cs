using portalSQL.Models;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using System;

namespace portalSQL.Controllers
{
    public class QueryController : ApiController
    {

        //DB CONNECTIONS
        PCERuntimeEntities PCE = new PCERuntimeEntities();
        EDFDesignEntities EDF = new EDFDesignEntities();
        ETMRuntimeEntities ETM = new ETMRuntimeEntities();

        //DAProcess
        [HttpGet]
        [Route("api/Query/DAProcess/{searchS}/{id}")]
        public IHttpActionResult DAProcess(string searchS, string id)
        {
            var status = PCE.DAProcesses.Where(e => e.Status == e.Status).ToList();
            var BizType = PCE.BizProcessTypes.Where(x => x.Code == x.Code).ToList();
            var statusCode = EDF.DAProcessStatus.ToList();
            var procName = EDF.Products.ToList();

            var results = (from s in status
                          // .Where(x => x.BizProcCode == id)
                           join sc in statusCode on s.Status equals sc.Code
                           join pn in procName on s.ProductCode equals pn.Code
                           join bt in BizType on s.BizProcCode equals bt.Code
                           select new
                           {
                               s.SeqNbr,
                               s.ProductCode,
                               s.BizProcCode,
                               s.BizProcNbr,
                               s.Status,
                               s.BranchCode,
                               s.StatusDate,
                               s.StatusTime,
                               s.User,
                               s.UserLock,
                               s.CreationTime,
                               s.CreationUser,
                               s.CustomerName,
                               s.CustomerNbr,
                               s.ContractNbr,
                               s.Transit,
                               s.EntryChannel,
                               s.CentralStatus,
                               s.AssociatedDAProcessSeqNbr,
                               StatusDesc = sc.Description,
                               Produt = pn.Name,
                               Process = bt.Name
                           }
                   ).ToList();


            if (searchS == "PROCESS")
            {
                var res = results.Where(x => x.BizProcNbr == id).ToList();
                return Ok(res);
            };

            if (searchS == "CONTRACT")
            {
                var res = results.Where(x => x.ContractNbr == id).ToList();
                return Ok(res);
            };

            if (searchS == "NIF")
            {
                var res = results.Where(x => x.CustomerNbr == id).ToList();
                 return Ok(res);
            }

               if (searchS == "SEQNBR")
            {
               long l = long.Parse(id); //convert o id que vem como string p
               var res = results.Where(x => x.SeqNbr == l).ToList();
               return Ok(res);
            }
           
            return Ok();
        }

        //DAProcessDoc
        [HttpGet]
        public IHttpActionResult DAProcessDoc(string id)
        {
            var s = PCE.DAProcessDocs
                .Include(x => x.DAProcess)
                .Where(y => y.DAProcess.BizProcNbr == id)
                .ToList()
                .Select(r => new
                {
                    r.SeqNbr,
                    r.DAProcessSeqNbr,
                    r.DocTypeCode,
                    r.Path,
                    r.Version,
                    r.DocStatusCode,
                    r.Status,
                    r.StatusDate,
                    r.StatusTime,
                    r.Motive,
                    r.IndManualAttach,
                    r.AttachmentDate,
                    r.AttachmentTime,
                    r.IsMandatory,
                    r.ExternalDocID,
                    r.CustomerNbr,
                    r.Source,
                    r.NbrPages,
                    r.Barcode,
                    r.Order,
                    r.Deleted,
                    r.ValidationTypeCode,
                    r.DigitalValidationCode,
                    r.PhysicalValidationCode,
                    r.BatchID,
                    r.IsSignedPrimaryHolder,
                    r.IsSignedSecondaryHolder,
                    r.ProofDocCode,
                    r.CanAttach,
                    r.SignatureRequired,
                    r.MinPages,
                    r.MaxPages,
                    r.IsActive,
                }).ToList();

            return Ok(s);
        }


        //DAProcessWorkQueue
        [HttpGet]
        public IHttpActionResult DAProcessWorkQueue(string id)
        {
            var s = PCE.DAProcessWorkQueues
                .Include(x => x.DAProcess)
                .Where(y => y.DAProcess.BizProcNbr == id)
                .Select(z => new { 
                    z.DAProcessSeqNbr,
                    z.WorkQueueCode,
                    z.AssignDate,
                    z.AssignTime,
                    z.Delay,
                    z.Priority
                }).ToList();
            return Ok(s);
        }


        //DAProcessAnomaly
        [HttpGet]
        public IHttpActionResult DAProcessAnomaly(string id)
        {
            var s = PCE.DAProcessAnomalies
                .Where(y => y.BizProcNbr == id)
                .Join(PCE.Anomalies,
                  x => x.AnomalyCode,
                  y => y.Code,
                  (x, y) => new
                  {
                      Code = y.Code,
                      Description = y.Description,
                      AnomalyTypeCode = y.AnomalyTypeCode,
                      ProofTypeCode = y.ProofTypeCode,
                      HolderNbr = y.HolderNbr,
                      AnomalyThemeCode = y.AnomalyThemeCode,
                      AnomalyDateTime = x.AnomalyDateTime,
                      CreationUser = x.CreationUser,
                      Resolved = x.Resolved,
                      ResolvedDate = x.ResolvedDate,
                      ResolvedUser = x.ResolvedUser
                  }).ToList();
            //ver se é preciso fazer o 2 INNER JOIN
            return Ok(s);
        }

        //DAProcessOperation
        [HttpGet]
        public IHttpActionResult DAProcessOperation(string id)
        {
            var dapoStatus = PCE.DAProcessOperations.Where(x => x.DAProcessStatus == x.DAProcessStatus).ToList();
            var dasNbr = PCE.DAProcesses.Where(j => j.SeqNbr == j.SeqNbr).ToList();
            var dapsCode = EDF.DAProcessStatus.ToList();

            var results = (from dnb in dasNbr
                           .Where(x => x.BizProcNbr == id)
                           join s in dapoStatus on dnb.SeqNbr equals s.DAProcessSeqNbr
                           join dc in dapsCode on s.DAProcessStatus equals dc.Code
                           select new
                            {
                                s.OpDate,
                                s.OpTime,
                                OpUser = s.User,
                                OpStatusCode = dc.Description,
                                OpStatusDesc = dc.Code
                            }).ToList()
                            .OrderBy(j => j.OpDate);
            return Ok(results);
        }

        //TJ Branch
        [HttpGet]
        public IHttpActionResult TJBranch(string id)
        {
           var tj =  ETM.TJ_Branch
                .Where(x => x.AcctNbr == id)
                .Select(z => new {
                    z.UserName,
                    z.ProcDate,
                    z.ProcTime,
                    z.Channel,
                    z.Branch,
                    z.TxnCode,
                    z.Status,
                    z.SysError,
                    z.UserMsg,
                    z.TxnDetail
                }).ToList()
                .OrderBy(o => o.ProcDate);
            return Ok(tj);
        }

        //Process Signature
        [HttpGet]
        public IHttpActionResult Signature(string id)
        {
            var ps = PCE.DAProcessSignatures
                .Include(x => x.DAProcess)
                .Where(x => x.DAProcess.BizProcNbr == id)
                .Select( j => new
                {
                    j.SeqNbr,
                    j.DAProcessSeqNbr,
                    j.SignatureKey,
                    j.StatusDate,
                    j.StatusTime,
                    j.Status,
                    j.DAProcessDocSeqNbr,
                    j.SignatureTypeCode
                }).ToList();

            return Ok(ps);
        }
    }

}
