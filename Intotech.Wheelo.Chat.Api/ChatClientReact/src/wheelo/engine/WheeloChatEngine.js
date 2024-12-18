import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';



export default class WheeloChatEngine {

    constructor(receiveMsgCall, connectedCallback, inviteToConv) {

        this.receiveMessageCall = receiveMsgCall;
        this.connectedCall = connectedCallback;
        this.inviteToConvCall = inviteToConv;
    }

    connection;
    messages = [];
    room;
    receiveMessageCall;
    connectedCall;
    inviteToConvCall;

    //serverUrl = "http://localhost:5130/wheeloChat";
    serverUrl = "http://20.203.135.11:5130/wheeloChat";
    //serverUrl = "http://192.168.0.158:5130/wheeloChat"; 
    ReceiveMessageCallback = "getMessage"; // react callback
    joinRoomDelegate = "JoinWheeloRoom"; //method in c#
    sendMessageCallback = "SendMessage"; 
    connectUserDelegate = "ConnectUser"; //method in c#
    addUserCallback = "session"; // react callback
    inviteToConversationCallback = "InviteToConversation"; // react callback
    requestConversationDelegate = "CreateRoom"; //method in c#
    approveChatDelegate = "ApproveChat"; // c#

    initialize = async () => {

        this.connection = new HubConnectionBuilder()
            .withUrl(this.serverUrl, {
                accessTokenFactory: () => "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImJ6YXBhcnRAZ21haWwuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IkJhcnRlayBaYXBhcnQiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxNjczODA4Mzk0LCJpc3MiOiJodHRwOi8vaW50b3RlY2guY29tLnBsIiwiYXVkIjoiaHR0cDovL2ludG90ZWNoLmNvbS5wbCJ9.KQ2ln8GAzQe5g2HDTAfLvC2ctOLH3JIzAj3MH1fLD34"
              })
            .configureLogging(LogLevel.Error)
            .build();

        console.log("Connection: ", this.connection);

        this.connection.on(this.ReceiveMessageCallback, (msgDto) => {
            console.log("getMessage", msgDto);
            this.receiveMessageCall(msgDto);
            //this.messages = [...this.messages, { user, message }];
        });

        this.connection.on("PocResponse", (dto) => {

            console.log("PocResponse", dto);
            
        });

        this.connection.on("RoomEstablished", (dto) => {

            console.log("RoomEstablished, invoking JoinRoom", dto.room, dto.room.idRoom);

            this.connection.invoke("JoinRoom", parseInt(dto.room.idRoom));
            
        });

        this.connection.on(this.addUserCallback, (chatUser) => {

            console.log("Connected with data: ", chatUser);
        
            this.connectedCall(chatUser);
        });

        this.connection.on(this.inviteToConversationCallback, (dto) => {

            console.log("invite", dto);
            this.inviteToConvCall(dto);
        });

        this.connection.onclose(e => {
            this.connection = null;
        });
        
        await this.connection.start();
    }

    userConnect = async (email) => {

        console.log("accountId", email);
        try{
            await this.connection.invoke(this.connectUserDelegate, email);
        }
        catch (e) {
            console.log(e);
        }
    }

    requestConversation = async () => {
        
        await this.connection.invoke(this.requestConversationDelegate, "bzapart@gmail.com", new Array("warriorr@poczta.fm", "bartek@gg.pl"));
    }

    ProofOfConcept = async(userId) => {

        await this.connection.invoke("ProofOfConcept", userId);
    }

    sendMessage = async (authorAccountId, targetId, message) => {
        try {
          console.log("dafaq", authorAccountId);
          await this.connection.invoke(this.sendMessageCallback, 
            {
             SenderID: authorAccountId,
             Text: message,
             ID: targetId,
             CreatedAt: "2023-01-07",
             AuthorFirstName: "Bartek",
             AuthorLastName: "Zapart",
             RoomID: targetId
            }); 
/*
        public string SenderID { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ID { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public int RoomID { get; set; }*/
        } catch (e) {
          console.log(e);
        }
    }

    approveChat = async (participantId, roomId) => {

        await this.connection.invoke(this.approveChatDelegate, parseInt(participantId), parseInt(roomId));
    }
}