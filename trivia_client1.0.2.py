import socket
import struct

PORT = 7348
SERVER_IP = "127.0.0.1"
LOGIN_CODE = '2'.encode('utf-8')
SIGNUP_CODE = '3'.encode('utf-8')
SIZE_LENGTH = 16


def send_hello():
    try:
        # Create a TCP/IP socket
        with socket.socket() as client_socket:
            client_socket.connect((SERVER_IP, PORT))
            with client_socket:
                print("Client connected")

                handle_kind_msg(client_socket)

                # getting the response from the server
                data = client_socket.recv(1024)
                print(data)

    except socket.error as erMsg:
        print("Socket error: " + str(erMsg) + "\n" + "Retrying...")


def handle_kind_msg(client_socket):
    kind_msg = "SIGNUP"#input("enter kind of message")
    msg_data = ""
    msg = ""
    username = 'nir'#input("enter name of user: ")
    password = 'abcde'#input("enter password of username: ")
    if kind_msg == "LOGIN":
        # create msg in json format (msg_data) from the received information
        msg_data = '{"username": "' + username + '", "password": "' + password + '"}'

        print('{:04d}'.format(len(msg_data)).encode('latin-1'))
        msg = LOGIN_CODE + '{:04d}'.format(len(msg_data)).encode('latin-1') + msg_data.encode('utf-8')

    elif kind_msg == "SIGNUP":
        mail = input("enter mail: ")
        # create msg in json format (msg_data) from the received information
        msg_data = '{"username": "' + username + '", "password": "' + password + '", "mail": "' + mail + '"}'
        print(msg_data)
        msg = SIGNUP_CODE + '{:04d}'.format(len(msg_data)).encode('latin-1') + msg_data.encode('utf-8')

    print("the message sent to the server: " + msg.decode())
    #client_socket.send(msg)


def main():
    send_hello()


if __name__ == "__main__":
    main()