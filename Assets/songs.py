import os
import shutil

# Ο φάκελος που περιέχει τους φακέλους τραγουδιών
main_folder = 'png'

# Βρόχος που περνάει από όλους τους φακέλους μέσα στον κύριο φάκελο
for folder_name in os.listdir(main_folder):
    folder_path = os.path.join(main_folder, folder_name)

    # Ελέγχει αν ο "φάκελος" είναι πραγματικά φάκελος
    if os.path.isdir(folder_path):
        image_path = os.path.join(folder_path, '0')
        
        # Ελέγχει αν το αρχείο "0" υπάρχει στον φάκελο
        if os.path.isfile(image_path):
            new_image_name = f"{folder_name}.png"
            new_image_path = os.path.join(main_folder, new_image_name)
            
            # Μετακινεί και μετονομάζει την εικόνα
            shutil.move(image_path, new_image_path)
        
        # Διαγράφει τον αρχικό φάκελο αφού έχει μετακινήσει την εικόνα
        shutil.rmtree(folder_path)

print("Η διαδικασία ολοκληρώθηκε.")
