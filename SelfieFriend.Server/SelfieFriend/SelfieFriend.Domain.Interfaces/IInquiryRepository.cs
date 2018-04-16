using System.Collections.Generic;
using SelfieFriend.Domain.Core;

namespace SelfieFriend.Domain.Interfaces
{
    public interface IInquiryRepository //:IRepository<Inquiry>
    {
        List<Inquiry> GetList();

        Inquiry Get(int id);

        Inquiry GetByOfferingId(int vkId, int offeringId);

        List<Inquiry> GetListByVkId(int id);

        /// <summary>
        /// Проверяет подал ли заявку пользователь с заданым VkID на предложение с заданнымм offeringID
        /// </summary>
        /// <param name="vkId">VkId пользователя который мог подать заявку на предложение</param>
        /// <param name="offeringId">id предложения на которое пользователь мог подать заявку</param>
        /// <returns>Возвращает true в случае если пользователь подписался на заявку, иначе false</returns>
        bool IsInquiredOffering(int vkId, int offeringId);

        void Create(Inquiry item);

        void Update(Inquiry item);

        void Delete(int id);

        List<Inquiry> GetListForUser(User user);

        List<Inquiry> GetUserList(User user);
    }
}
