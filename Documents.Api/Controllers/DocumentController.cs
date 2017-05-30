using System;
using System.Web.Http;
using System.Web.Http.Description;
using DataAccess.Domains.Documents;
using System.Threading.Tasks;
using Entities.Documents;
using System.Collections.Generic;

namespace Documents.Api.Controllers
{
    /// <summary>
    /// Api que fornece recursos para manipular informações de Documentos.
    /// </summary>
    [RoutePrefix("api/documents")]
    public class DocumentController : ApiController
    {
        #region Private Variables

        private readonly IDocumentDomain _IDocumentDomain;

        #endregion

        #region Constructor

        public DocumentController(IDocumentDomain documentDomain)
        {
            _IDocumentDomain = documentDomain;
        }

        #endregion

        #region Actions

        /// <summary>
        /// Recurso que insere um novo documento.
        /// </summary>
        /// <param name="document">Entidade Document</param>
        /// <returns>Documento inserido</returns>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Document))]
        public async Task<IHttpActionResult> Post([FromBody] Document document)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var documentInserted = await _IDocumentDomain.Insert(document);

                    if (documentInserted != null)
                        return Ok(documentInserted);
                    else
                        return BadRequest();
                }
                else
                    return BadRequest(ModelState);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Recurso que atualiza informações de um documento.
        /// </summary>
        /// <param name="documentId">Id do documento</param>
        /// <param name="document">Entidade Document com informações atualizadas</param>
        /// <returns>Documento atualizado</returns>
        [HttpPut]
        [Route("{documentId:int}")]
        [ResponseType(typeof(Document))]
        public async Task<IHttpActionResult> Put(int documentId, [FromBody] Document document)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var documentUpdated = await _IDocumentDomain.Update(documentId, document);

                    if (documentUpdated != null)
                        return Ok(documentUpdated);
                    else
                        return BadRequest();
                }
                else
                    return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Recurso que exclui um documento.
        /// </summary>
        /// <param name="documentId">Id do documento</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{documentId:int}")]
        public async Task<IHttpActionResult> Delete(int documentId)
        {
            try
            {
                await _IDocumentDomain.Delete(documentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Recurso que retorna a lista de documentos cadastrados.
        /// </summary>
        /// <returns>Lista de documentos cadastrados</returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(ICollection<Document>))]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var documents = await _IDocumentDomain.ListAll();
                return Ok(documents);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Recurso que retorna o documento a partir do seu Id.
        /// </summary>
        /// <param name="documentId">Id do documento</param>
        /// <returns>Entidade Document</returns>
        [HttpGet]
        [Route("{documentId:int}")]
        [ResponseType(typeof(Document))]
        public async Task<IHttpActionResult> Get(int documentId)
        {
            try
            {
                var document = await _IDocumentDomain.Find(documentId);
                return Ok(document);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        #endregion
    }
}
