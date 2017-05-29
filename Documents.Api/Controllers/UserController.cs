using System;
using System.Web.Http;
using System.Web.Http.Description;
using DataAccess.Domains.Users;
using System.Threading.Tasks;
using Entities.Users;
using System.Collections.Generic;

namespace Documents.Api.Controllers
{  
    /// <summary>
    /// Api que fornece recursos para manipular informações de Usuários.
    /// </summary>
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        #region Private Variables

        private readonly UserDomain _userDomain = new UserDomain();

        #endregion

        #region Actions

        /// <summary>
        /// Recurso que insere um novo usuário.
        /// </summary>
        /// <param name="user">Entidade User</param>
        /// <returns>Usuário inserido</returns>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> Post([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userInserted = await _userDomain.Insert(user);

                    if (userInserted != null)
                        return Ok(userInserted);
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
        /// Recurso que atualiza informações de um usuário.
        /// </summary>
        /// <param name="userId">Id do usuário</param>
        /// <param name="user">Entidade User com informações atualizadas</param>
        /// <returns>Usuário atualizado</returns>
        [HttpPut]
        [Route("{userId:int}")]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> Put(int userId, [FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userUpdated = await _userDomain.Update(userId, user);

                    if (userUpdated != null)
                        return Ok(userUpdated);
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
        /// Recurso que exclui um usuário.
        /// </summary>
        /// <param name="userId">Id do usuário</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{userId:int}")]
        public async Task<IHttpActionResult> Delete(int userId)
        {
            try
            {
                await _userDomain.Delete(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Recurso que retorna a lista de usuários cadastrados.
        /// </summary>
        /// <returns>Lista de usuários cadastrados</returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(ICollection<User>))]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var users = await _userDomain.ListAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Recurso que retorna o usuário a partir do seu Id.
        /// </summary>
        /// <param name="userId">Id do usuário</param>
        /// <returns>Entidade User</returns>
        [HttpGet]
        [Route("{userId:int}")]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> Get(int userId)
        {
            try
            {
                var user = await _userDomain.Find(userId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        #endregion
    }
}
