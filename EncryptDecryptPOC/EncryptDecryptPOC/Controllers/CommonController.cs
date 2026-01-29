using EncryptDecryptPOC.Common;
using EncryptDecryptPOC.Model;
using Microsoft.AspNetCore.Mvc;

namespace EncryptDecryptPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly CommonComponent _commonComponent;

        public CommonController(CommonComponent commonComponent)
        {
            _commonComponent = commonComponent;
        }

        // AES
        [HttpPost("encrypt/aes")]
        public IActionResult EncryptAES([FromBody] InputModel model)
        {
            var result = _commonComponent.EncryptAES(model.input);
            return Ok(new { output = result });
        }

        [HttpPost("decrypt/aes")]
        public IActionResult DecryptAES([FromBody] InputModel model)
        {
            var result = _commonComponent.DecryptAES(model.input);
            return Ok(new { output = result });
        }

        // RSA
        [HttpPost("encrypt/rsa")]
        public IActionResult EncryptRSA([FromBody] InputModel model)
        {
            var result = _commonComponent.EncryptRSA(model.input);
            return Ok(new { output = result });
        }

        [HttpPost("decrypt/rsa")]
        public IActionResult DecryptRSA([FromBody] InputModel model)
        {
            var result = _commonComponent.DecryptRSA(model.input);
            return Ok(new { output = result });
        }

        // Triple DES
        [HttpPost("encrypt/TripleDes")]
        public IActionResult EncryptTripleDES([FromBody] InputModel model)
        {
            var result = _commonComponent.EncryptDES(model.input);
            return Ok(new { output = result });
        }

        [HttpPost("decrypt/TripleDes")]
        public IActionResult DecryptTripleDES([FromBody] InputModel model)
        {
            var result = _commonComponent.DecryptDES(model.input);
            return Ok(new { output = result });
        }

        // ECC
        [HttpPost("encrypt/ecc")]
        public IActionResult EncryptECC([FromBody] InputModel model)
        {
            var encryptedBytes = _commonComponent.EncryptECC(model.input);
            var result = Convert.ToBase64String(encryptedBytes);

            return Ok(new { output = result });
        }

        [HttpPost("decrypt/ecc")]
        public IActionResult DecryptECC([FromBody] InputModel model)
        {
            var bytes = Convert.FromBase64String(model.input);
            var result = _commonComponent.DecryptECC(bytes);

            return Ok(new { output = result });
        }

        // Twofish
        [HttpPost("encrypt/twofish")]
        public IActionResult EncryptTwofish([FromBody] InputModel model)
        {
            var result = _commonComponent.EncryptTwofish(model.input);
            return Ok(new { output = result });
        }

        [HttpPost("decrypt/twofish")]
        public IActionResult DecryptTwofish([FromBody] InputModel model)
        {
            var result = _commonComponent.DecryptTwofish(model.input);
            return Ok(new { output = result });
        }

        // Blowfish
        [HttpPost("encrypt/blowfish")]
        public IActionResult EncryptBlowfish([FromBody] InputModel model)
        {
            var result = _commonComponent.EncryptBlowfish(model.input);
            return Ok(new { output = result });
        }

        [HttpPost("decrypt/blowfish")]
        public IActionResult DecryptBlowfish([FromBody] InputModel model)
        {
            var result = _commonComponent.DecryptBlowfish(model.input);
            return Ok(new { output = result });
        }
    }
}
