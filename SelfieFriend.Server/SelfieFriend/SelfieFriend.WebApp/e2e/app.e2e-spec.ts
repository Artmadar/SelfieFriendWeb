import { SelfieFriend.WebAppPage } from './app.po';

describe('selfie-friend.web-app App', () => {
  let page: SelfieFriend.WebAppPage;

  beforeEach(() => {
    page = new SelfieFriend.WebAppPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
