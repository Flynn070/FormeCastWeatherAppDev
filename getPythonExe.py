import sys

with open("pythonExe.txt", "w") as outfile:
    outfile.write(sys.executable)