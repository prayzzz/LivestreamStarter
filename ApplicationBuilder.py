import fileinput
import sys
import getopt
import os
import glob
import shutil

allowedFileExtensions = [".dll", ".exe"]

## Main
def main(argv):
    print("## Welcome")
    print()

    sourceDir = ""
    destinationDir = ""

    try:
        opts, args = getopt.getopt(argv,"hs:d:",["sFolder=","dFolder="])
    except getopt.GetoptError:
        printHelp()
        exit(2)

    for opt, arg in opts:
        if opt == "-h":
            printHelp()
            exit(0)
        elif opt in ("-s", "--sFolder"):
            sourceDir = arg
        elif opt in ("-d", "--dFolder"):
            destinationDir = arg.rstrip("\\").rstrip("\"")

    if checkArguments(sourceDir, "sourceDir", False) == False:
        exit(0)

    if checkArguments(destinationDir, "destinationDir", True) == False:
        exit(0)

    copyFiles(sourceDir, destinationDir)

def copyFiles(s, d):
    print("Copying files:")

    i = 0
    for root, dirs, files in os.walk(s):
        for file in files:
            if isFileAllowed(file):
                 path = os.path.join(root, file)
                 dirname = os.path.dirname(path)[len(s) + 1:]

                 destinationDir = os.path.join(d, dirname)
                 destinationFile = os.path.join(destinationDir, file)
                 
                 makeDir(destinationDir)
                 shutil.copy2(path, destinationFile)

                 print("Copied:", destinationFile)
                 i = i + 1

    print("## " + str(i) + " Files copied")

def makeDir(d):
    if os.path.isdir(d) == False:
        os.mkdir(d)

def isFileAllowed(f):
    for e in allowedFileExtensions:
        if f.endswith(e):
            return True
        else:
            return False

def checkArguments(d, n, make):
    print("Checking " + n + ":", d)

    if len(d) == 0:
        print("No Folder specified:", n)
        return False

    if make:
        makeDir(d)
    else:
        if os.path.isdir(d) == False:
            print("Folder doesn't exist:", d)
            return False

    print("## ok")
    print()
    return True

def printHelp():
    print("ApplicationBuilder.py -i <sourceDir> -d <destinationDir>")

def exit(code):
    sys.exit(code)

## Entry Point
if __name__ == "__main__":
    main(sys.argv[1:])