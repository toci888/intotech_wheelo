import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

export default class WheeloChatEngine {

    constructor(receiveMsgCall) {

        this.receiveMessageCall = receiveMsgCall;
    }

    connection;
    messages = [];
    room;
    receiveMessageCall;

    serverUrl = "https://localhost:7082/wheeloChat";
    ReceiveMessageCallback = "ReceiveMessage";
    joinRoomCallback = "JoinWheeloRoom";
    sendMessageCallback = "SendMessage";

    joinRoomClient = async (room) => {

        this.room = room;

        this.connection = new HubConnectionBuilder()
            .withUrl(this.serverUrl)
            .configureLogging(LogLevel.Information)
            .build();

        this.connection.on(this.ReceiveMessageCallback, (msgDto) => {
            
            console.log("msgDto", msgDto);
            this.receiveMessageCall(msgDto.user.userName, msgDto.message);
            //this.messages = [...this.messages, { user, message }];
        });

        this.connection.onclose(e => {
            this.connection = null;
        });

        try{

        await this.connection.start();

        await this.connection.invoke(this.joinRoomCallback, this.room);

}catch (e) {
    console.log(e);
  }
        console.log('end of join room');
        //setConnection(connection);
    }

    sendMessage = async (message, user) => {
        try {
          //console.log(message, user, connection, room);
          await this.connection.invoke(this.sendMessageCallback, 
            {  user: 
                { UserId: 1, UserName: user },
                Message: message,
                RoomId: 'WheeloHeroes'
            }); //message, user, this.room

        } catch (e) {
          console.log(e);
        }
      }
}