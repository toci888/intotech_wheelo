import { Platform } from "react-native";

export const chatApiKey = 'g9qa6ucyf3ff';

let chatUserId: string;
let chatUserToken: string;
let chatUserName: string;

if(Platform.OS === 'ios') {
    chatUserId = 'testUser1';
    chatUserToken = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyX2lkIjoidGVzdFVzZXIxIn0.QB1N-a6VZTVJSV94uBLXJqeoDIjkOGRvGeO1Lizg-wY';
    chatUserName = 'testUser1';
} else {
    chatUserId = 'testUser2';
    chatUserToken = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyX2lkIjoidGVzdFVzZXIyIn0.7rXB9L4tTVB6s7VD4qLq-9htUfFChGPj5syrOJGZQac';
    chatUserName = 'testUser2';
}

export { chatUserId, chatUserToken, chatUserName };

// export const chatUser1Id = 'testUser1';
// export const chatUser1Token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyX2lkIjoidGVzdFVzZXIxIn0.QB1N-a6VZTVJSV94uBLXJqeoDIjkOGRvGeO1Lizg-wY';
// export const chatUser1Name = 'testUser1';

// export const chatUser2Id = 'testUser2';
// export const chatUser2Token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyX2lkIjoidGVzdFVzZXIyIn0.7rXB9L4tTVB6s7VD4qLq-9htUfFChGPj5syrOJGZQac';
// export const chatUser2Name = 'testUser2';

// export const chatUser3Id = 'testUser3';
// export const chatUser3Token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyX2lkIjoidGVzdFVzZXIzIn0.SaPDzj3gMdCqEmrPtwMtMmKbGcV1Ik2ufretLlqS3yA';
// export const chatUser3Name = 'testUser3';

// export const chatUser4Id = 'testUser4';
// export const chatUser4Token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyX2lkIjoidGVzdFVzZXI0In0.msuojppGn0CdaV8Swr-3qFgJngEbwWke7Yc30gmJpKA';
// export const chatUser4Name = 'testUser4';
