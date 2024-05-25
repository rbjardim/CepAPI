using CepAPI.Interface.Service;
using CepAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CepAPI.Pages
{
    public class LocalModel : PageModel
    {
        private readonly ILocalizacaoService _localizacaoService;
        private readonly UserManager<AplicationUser> _userManager;

        public LocalModel(ILocalizacaoService localizacaoService, UserManager<AplicationUser> userManager)
        {
            _localizacaoService = localizacaoService;
            _userManager = userManager;
        }

        [BindProperty]
        public Localizacao Localizacao { get; set; }
        public IList<Localizacao> Localizacoes { get; private set; }

        public async Task OnGetAsync()
        {
            Localizacoes = await _localizacaoService.ListLocal();
        }

        public async Task<IActionResult> OnGetDetailsAsync(int id)
        {
            Localizacoes = await _localizacaoService.ListLocal();
            Localizacao = Localizacoes.FirstOrDefault(l => l.Id == id);
            if (Localizacao == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Login");
            }

            // Localizacao.UserId = user.Id;
            try
            {
                await _localizacaoService.CreateLocalizacao(Localizacao);
                TempData["Message"] = "Registro salvo!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Erro ao salvar informações: " + ex.Message;
                return Page();
            }

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostUpdateAsync(int id)
        {
            if (id != Localizacao.Id)
            {
                return BadRequest();
            }

            try
            {
                var result = await _localizacaoService.UpdateLocalizacao(Localizacao);
                if (result == 0)
                {
                    return NotFound();
                }
                TempData["Message"] = "Registro atualizado!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Erro ao atualizar informações: " + ex.Message;
                return Page();
            }

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try
            {
                var result = await _localizacaoService.DeleteLocalAsync(id);
                if (!result)
                {
                    return NotFound();
                }
                TempData["Message"] = "Registro deletado!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Erro ao deletar informações: " + ex.Message;
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
